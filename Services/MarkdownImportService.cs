﻿using RaGuideDesigner.Models;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Text;
using System.Collections.Generic;

namespace RaGuideDesigner.Services
{
    public class MarkdownImportService
    {
        // A utility that takes a raw text block and separates out any admonition notes.
        // It populates a list with the found admonitions and returns the remaining text.
        private string ProcessBlock(string rawBlock, BindingList<Admonition> admonitions)
        {
            if (string.IsNullOrWhiteSpace(rawBlock))
            {
                return "";
            }

            string processedBlock = Regex.Replace(rawBlock, @"<br\s*/?>", "\n", RegexOptions.IgnoreCase);
            var admonitionMatches = Regex.Matches(processedBlock, @"> \[!(.*?)\]\s*\n((?:> .*\s*\n?)*)", RegexOptions.Singleline);
            var sb = new StringBuilder(processedBlock);
            foreach (Match match in admonitionMatches.Cast<Match>().Reverse())
            {
                sb.Remove(match.Index, match.Length);
                var type = match.Groups[1].Value.Trim();
                var admonitionContent = match.Groups[2].Value.Trim();
                var cleanedContent = string.Join("\n", admonitionContent.Split('\n')
                    .Select(line => line.Trim().StartsWith(">") ? line.Trim().Substring(1).Trim() : line.Trim()));
                admonitions.Add(new Admonition { Type = type, Content = cleanedContent });
            }
            var reversedAdmonitions = admonitions.Reverse().ToList();
            admonitions.Clear();
            foreach (var adm in reversedAdmonitions)
            {
                admonitions.Add(adm);
            }
            return sb.ToString().Trim();
        }

        // Deconstructs the markdown from a single achievement's guidance cell back into structured data.
        // This is a multi-step process that pulls out notes, admonitions, and then splits the remaining
        // content by headers (like "Fail Conditions") to populate the achievement's properties.
        private void ParseAchievementGuidance(Achievement ach, string rawContent)
        {
            string content = rawContent.Replace("<br>", "\n").Trim();

            // 1. Extract and remove Misc/Dev Notes first.
            var noteRegex = new Regex(@"\s*<sub>\s*\*\*(\w+)\s*note\s*[-—⁃]?\s*\*\*\s*\*(.*?)\*\s*</sub>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            var noteMatches = noteRegex.Matches(content);
            foreach (Match match in noteMatches.Cast<Match>().Reverse())
            {
                string noteType = match.Groups[1].Value;
                string noteText = match.Groups[2].Value.Trim();

                if (noteType.Equals("Misc", StringComparison.OrdinalIgnoreCase))
                {
                    ach.MiscNote = noteText;
                }
                else if (noteType.Equals("Dev", StringComparison.OrdinalIgnoreCase))
                {
                    ach.DevNote = noteText;
                }
                content = content.Remove(match.Index, match.Length);
            }

            // 2. Extract Admonitions and remove them.
            var contentBuilder = new StringBuilder(content);
            var admonitionMatches = Regex.Matches(content, @"\s*> \[!(.*?)\]\s*\n((?:> .*\s*\n?)*)", RegexOptions.Singleline);
            foreach (Match match in admonitionMatches.Cast<Match>().Reverse())
            {
                contentBuilder.Remove(match.Index, match.Length);
                var type = match.Groups[1].Value.Trim();
                var admonitionContent = match.Groups[2].Value.Trim();
                var cleanedContent = string.Join("\n", admonitionContent.Split('\n').Select(line => line.Trim().StartsWith(">") ? line.Trim().Substring(1).Trim() : line.Trim()));
                ach.Admonitions.Add(new Admonition { Type = type, Content = cleanedContent });
            }
            if (ach.Admonitions.Any()) ach.Admonitions.Reverse();
            string remainingContent = contentBuilder.ToString().Trim();

            // 3. Split what's left into logical sections based on the <h4> headers.
            var sections = Regex.Split(remainingContent, @"\s*(?=<h4>)");

            string mainDescriptionBlock = sections[0];
            var videoMatch = Regex.Match(mainDescriptionBlock, @"\s*\[▶️ Watch Video Walkthrough\]\((.*?)\)");
            if (videoMatch.Success)
            {
                ach.VideoWalkthroughUrl = videoMatch.Groups[1].Value.Trim();
                ach.GuidanceAndInsights = mainDescriptionBlock.Substring(0, videoMatch.Index).Trim();
            }
            else
            {
                ach.GuidanceAndInsights = mainDescriptionBlock.Trim();
            }

            // 4. Process the remaining sections (Fail Conditions, Tracking).
            foreach (var section in sections.Skip(1))
            {
                if (section.StartsWith("<h4>Fail Conditions</h4>"))
                {
                    string listContent = section.Replace("<h4>Fail Conditions</h4>", "").Trim();
                    var conditions = listContent.Split(new[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
                    foreach (var condition in conditions)
                    {
                        var trimmedCondition = condition.Trim();
                        if (trimmedCondition.StartsWith("-"))
                        {
                            ach.FailConditions.Add(trimmedCondition.Substring(1).Trim());
                        }
                    }
                }
                else if (section.StartsWith("<h4>Achievement Tracking</h4>"))
                {
                    string listContent = section.Replace("<h4>Achievement Tracking</h4>", "").Trim();
                    var triggerMatch = Regex.Match(listContent, @"- A \[Trigger Indicator\].*?\) (.*)");
                    if (triggerMatch.Success)
                    {
                        ach.TriggerIndicator = triggerMatch.Groups[1].Value.Trim();
                    }

                    var measuredMatch = Regex.Match(listContent, @"- A \[Measured Indicator\].*?\) (.*)");
                    if (measuredMatch.Success)
                    {
                        ach.MeasuredIndicator = measuredMatch.Groups[1].Value.Trim();
                    }
                }
            }
        }

        public WikiGuide Parse(string filePath)
        {
            var content = File.ReadAllText(filePath);
            return ParseFromString(content);
        }

        // Reads a complete Markdown guide and parses it into a structured WikiGuide object.
        // It uses a series of regular expressions to identify and extract each major section
        // (header, resources, categories, leaderboards, credits, etc.) from the raw text.
        public WikiGuide ParseFromString(string content)
        {
            var guide = new WikiGuide();

            var headerMatch = Regex.Match(content, @"# \*\*.*?🔶 \*\*\*(.*?)\*\*\*.*?<sub><sup> \((.*?)\) </sup></sub>.*?<img .*?src=""([^""]+)"".*?---\s*(.*?)(?=<h3 id=ToC>)", RegexOptions.Singleline);
            if (headerMatch.Success)
            {
                guide.GameTitle = headerMatch.Groups[1].Value.Trim();
                string platformShortName = headerMatch.Groups[2].Value.Trim();
                guide.Platform = PlatformMappingService.GetFullName(platformShortName);
                guide.BannerImageUrl = headerMatch.Groups[3].Value.Trim();
                guide.IntroText = headerMatch.Groups[4].Value.Trim();
            }

            var masteryIconMatch = Regex.Match(content, @"<img align=""left"" width=""96"" height=""96"" src=""([^""]*)""");
            if (masteryIconMatch.Success) guide.MasteryIconUrl = masteryIconMatch.Groups[1].Value.Trim();

            var walkthroughsSectionMatch = Regex.Match(content, @"<h3 id=WalkthroughsResources>.*?</h3>\s*\r?\n(.*?)(?=\s*\r?\n\s*---)", RegexOptions.Singleline);
            if (walkthroughsSectionMatch.Success)
            {
                var walkthroughsContent = walkthroughsSectionMatch.Groups[1].Value;

                var guidesBlockMatch = Regex.Match(walkthroughsContent, @"#### 📚 Guides & Walkthroughs\s*\r?\n(.*?)(?=\s*####|###|$)", RegexOptions.Singleline);
                if (guidesBlockMatch.Success)
                {
                    var linkMatches = Regex.Matches(guidesBlockMatch.Groups[1].Value, @"-\s*\*\*\[(.*?)\]\((.*?)\)\*\*");
                    foreach (Match linkMatch in linkMatches)
                    {
                        guide.Guides.Add(new ResourceLink { Text = linkMatch.Groups[1].Value.Trim(), Url = linkMatch.Groups[2].Value.Trim() });
                    }
                }

                var playthroughsBlockMatch = Regex.Match(walkthroughsContent, @"#### 🎮 Playthroughs & Longplays\s*\r?\n(.*?)(?=\s*####|###|$)", RegexOptions.Singleline);
                if (playthroughsBlockMatch.Success)
                {
                    var linkMatches = Regex.Matches(playthroughsBlockMatch.Groups[1].Value, @"-\s*\*\*\[(.*?)\]\((.*?)\)\*\*");
                    foreach (Match linkMatch in linkMatches)
                    {
                        guide.Playthroughs.Add(new ResourceLink { Text = linkMatch.Groups[1].Value.Trim(), Url = linkMatch.Groups[2].Value.Trim() });
                    }
                }

                var adviceAndAdmonitionsBlock = Regex.Match(walkthroughsContent, @"(###\s*(🧠 General Advice.*))", RegexOptions.Singleline);
                if (adviceAndAdmonitionsBlock.Success)
                {
                    var admonitions = new BindingList<Admonition>();
                    guide.GeneralAdvice = ProcessBlock(adviceAndAdmonitionsBlock.Groups[1].Value, admonitions);
                    guide.Admonitions = admonitions;
                    var titleMatch = Regex.Match(guide.GeneralAdvice, @"^(###\s*🧠 General Advice.*?)\s*\n");
                    if (titleMatch.Success)
                    {
                        guide.GeneralAdviceTitle = titleMatch.Groups[1].Value.Replace("###", "").Trim();
                        guide.GeneralAdvice = guide.GeneralAdvice.Substring(titleMatch.Length).Trim();
                    }
                }
            }

            int totalPointsFromSummary = 0;
            var summaryPointsMatch = Regex.Match(content, @"Set consists of \d+ achievements worth (\d+) points");
            if (summaryPointsMatch.Success)
            {
                totalPointsFromSummary = int.Parse(summaryPointsMatch.Groups[1].Value);
            }

            var sections = Regex.Split(content, @"(?=<h1 id=)");
            foreach (var section in sections.Skip(1))
            {
                var categoryHeaderMatch = Regex.Match(section, @"<h1 id=([^>]+?)>\s*(.*?)\s(.*?)\s<i><sub><sup>\(\d+ achievements - (\d+) points\)</sup></sub></i>");
                if (categoryHeaderMatch.Success)
                {
                    var categoryId = categoryHeaderMatch.Groups[1].Value.Trim();
                    if (new[] { "Credits", "LeaderboardGuide", "AchievementGuide", "Footnotes" }.Contains(categoryId)) continue;

                    var category = new AchievementCategory
                    {
                        Icon = categoryHeaderMatch.Groups[2].Value.Trim(),
                        Title = categoryHeaderMatch.Groups[3].Value.Trim()
                    };
                    var categoryPoints = int.Parse(categoryHeaderMatch.Groups[4].Value);

                    var headerEndIndex = section.IndexOf("</h1>") + "</h1>".Length;

                    var tableHeaderRegex = new Regex(@"###\s+.*?\s+Achievement List");
                    var tableMatch = tableHeaderRegex.Match(section, headerEndIndex);
                    int tableStartIndex = tableMatch.Success ? tableMatch.Index : section.Length;
                    string headerContentBlock = section.Substring(headerEndIndex, tableStartIndex - headerEndIndex).Trim();

                    string descriptionAndAdmonitionsBlock = headerContentBlock;

                    var additionalNotesMatch = Regex.Match(headerContentBlock, @"(##\s+Additional Notes.*)", RegexOptions.Singleline);
                    if (additionalNotesMatch.Success)
                    {
                        descriptionAndAdmonitionsBlock = headerContentBlock.Substring(0, additionalNotesMatch.Index).Trim();
                        category.AdditionalNotes = additionalNotesMatch.Value.Trim();
                    }
                    else
                    {
                        category.AdditionalNotes = "";
                    }
                    var admonitions = new BindingList<Admonition>();
                    category.Description = ProcessBlock(descriptionAndAdmonitionsBlock, admonitions);
                    category.Admonitions = admonitions;

                    var achievementRowRegex = new Regex(@"\| <h3 id=(\d+?)>(\*\*.*?\*\*|.*?)<\/h3>.*?!\s*\[.*?\]\((.*?)\s*"".*?""\)\s*\|\s*(.*?)\s*\|(?=\r?\n\s*\| <h3|\r?\n\s*🔗|$)", RegexOptions.Singleline);
                    var matches = achievementRowRegex.Matches(section);
                    foreach (Match achRowMatch in matches)
                    {
                        var ach = new Achievement
                        {
                            Id = int.Parse(achRowMatch.Groups[1].Value),
                            Title = achRowMatch.Groups[2].Value.Replace("**", "").Trim(),
                            BadgeUrl = achRowMatch.Groups[3].Value.Trim()
                        };

                        string rawCellContent = achRowMatch.Groups[4].Value.Trim();
                        ach.GuidanceAndInsights = rawCellContent;

                        bool isProgression = category.Title.Equals("Progression", StringComparison.OrdinalIgnoreCase);

                        if (category.IsCollectibleType && rawCellContent.Contains("<u><b>"))
                        {
                            ach.ParseGuidanceAsCollectible();
                        }
                        else if (isProgression)
                        {
                            string cleanedContent = rawCellContent.Replace("<br>", "\n").Trim();
                            if (cleanedContent.StartsWith("- "))
                            {
                                cleanedContent = cleanedContent.Substring(2).Trim();
                            }
                            ach.GuidanceAndInsights = cleanedContent;
                        }
                        else
                        {
                            ParseAchievementGuidance(ach, rawCellContent);
                        }


                        category.Achievements.Add(ach);
                    }

                    if (category.Achievements.Any())
                    {
                        int pointsPerAch = categoryPoints / category.Achievements.Count;
                        int remainder = categoryPoints % category.Achievements.Count;
                        for (int i = 0; i < category.Achievements.Count; i++)
                        {
                            category.Achievements[i].Points = pointsPerAch + (i < remainder ? 1 : 0);
                        }
                    }

                    guide.AchievementCategories.Add(category);
                }
                else if (section.Contains("<h1 id=LeaderboardGuide>"))
                {
                    // Parse intro text
                    var introMatch = Regex.Match(section, @"</h1>\s*(.*?)\s*### Leaderboard List", RegexOptions.Singleline);
                    if (introMatch.Success)
                    {
                        guide.LeaderboardIntroText = introMatch.Groups[1].Value.Trim();
                    }

                    var lbRowsRegex = new Regex(@"\| <h3 id=.*?>(.*?)<\/h3>?\s*\|\s*(.*?)(?=\s*\r?\n\| <h3|\s*\r?\n🔗|$)", RegexOptions.Singleline);
                    foreach (Match match in lbRowsRegex.Matches(section))
                    {
                        var lb = new Leaderboard
                        {
                            Title = Regex.Replace(match.Groups[1].Value.Trim(), @"\*\*|<i>|</i>", "")
                        };

                        string rawCellContent = match.Groups[2].Value.Replace("<br>", "\n").Trim();

                        // Parse notes first and remove them from the content
                        var noteRegex = new Regex(@"\s*<sub>\s*\*\*(\w+)\s*note\s*[-—⁃]?\s*\*\*\s*\*(.*?)\*\s*</sub>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                        var noteMatches = noteRegex.Matches(rawCellContent);
                        foreach (Match noteMatch in noteMatches.Cast<Match>().Reverse())
                        {
                            string noteType = noteMatch.Groups[1].Value;
                            string noteText = noteMatch.Groups[2].Value.Trim();

                            if (noteType.Equals("Misc", StringComparison.OrdinalIgnoreCase)) lb.MiscNote = noteText;
                            else if (noteType.Equals("Dev", StringComparison.OrdinalIgnoreCase)) lb.DevNote = noteText;

                            rawCellContent = rawCellContent.Remove(noteMatch.Index, noteMatch.Length);
                        }

                        var contentSections = Regex.Split(rawCellContent, @"\s*(?=<h4>|<h5>)");

                        if (!contentSections[0].StartsWith("<h"))
                        {
                            lb.Description = contentSections[0].Trim().TrimStart('-').Trim();
                        }

                        foreach (var contentSection in contentSections)
                        {
                            if (contentSection.StartsWith("<h4>Start Requirements</h4>")) lb.StartRequirements = new BindingList<string>(GetListItems(contentSection));
                            else if (contentSection.StartsWith("<h4>Cancel Conditions</h4>")) lb.CancelConditions = new BindingList<string>(GetListItems(contentSection));
                            else if (contentSection.StartsWith("<h4>Submit Conditions</h4>")) lb.SubmitConditions = new BindingList<string>(GetListItems(contentSection));
                            else if (contentSection.StartsWith("<h4>Measured Value</h4>")) lb.MeasuredValue = new BindingList<string>(GetListItems(contentSection));
                        }
                        guide.Leaderboards.Add(lb);
                    }
                }
                else if (section.Contains("<h1 id=Credits>"))
                {
                    // This new regex is more flexible. It captures the entire second cell's content,
                    // which we then parse for role and details, instead of trying to match both in one go.
                    var creditRowsRegex = new Regex(@"\| <h4>\[(.*?)\]\(.*?\)</h4>.*?src=""([^""]*)"".*?\|(.*?)?(?=\r?\n\| <h4>|\r?\n<h1|$)", RegexOptions.Singleline);
                    foreach (Match match in creditRowsRegex.Matches(section))
                    {
                        string rawCellContent = match.Groups[3].Value.Trim();
                        string rawRole = "";
                        string rawDetailsBlock = "";

                        // Manually parse the role and the details from the raw cell content.
                        var roleMatch = Regex.Match(rawCellContent, @"<b>\s*(.*?)\s*</b>");
                        if (roleMatch.Success)
                        {
                            rawRole = roleMatch.Groups[1].Value.Trim();
                            // Check for details *after* the bolded role
                            int detailsStartIndex = roleMatch.Index + roleMatch.Length;
                            if (detailsStartIndex < rawCellContent.Length)
                            {
                                var detailsPart = rawCellContent.Substring(detailsStartIndex).Trim();
                                if (detailsPart.StartsWith("<br><br>"))
                                {
                                    rawDetailsBlock = detailsPart.Substring(8).Trim();
                                }
                            }
                        }

                        var lines = rawDetailsBlock.Replace("<br>", "\n").Split('\n');
                        var cleanedLines = lines.Select(line => {
                            var trimmedLine = line.Trim();
                            if (trimmedLine.StartsWith("- "))
                            {
                                return trimmedLine.Substring(2).Trim();
                            }
                            if (trimmedLine.StartsWith("-"))
                            {
                                return trimmedLine.Substring(1).Trim();
                            }
                            return trimmedLine;
                        });

                        var details = string.Join("\n", cleanedLines).Trim();

                        if (details.EndsWith("|"))
                        {
                            details = details.Substring(0, details.Length - 1).Trim();
                        }

                        // Clean the role string by removing markdown formatting before saving it.
                        var cleanedRole = rawRole.Replace("*", "").Replace("\\|", "|");

                        guide.Credits.Add(new Credit { Username = match.Groups[1].Value.Trim(), AvatarUrl = match.Groups[2].Value.Trim(), Role = cleanedRole, ContributionDetails = details });
                    }
                }
                else if (section.Contains("<h1 id=Footnotes>"))
                {
                    string footnoteContent = section;

                    var measuredExamplesMatch = Regex.Match(footnoteContent, @"<h4 id=RA_Measure>.*?</h4>.*?Examples\s*:\s*\n((?:>\s*.*?\n)*)", RegexOptions.Singleline);
                    if (measuredExamplesMatch.Success)
                    {
                        guide.MeasuredIndicatorExamples = ExtractBlockquoteListLines(measuredExamplesMatch.Groups[1].Value);
                    }

                    var triggerExamplesMatch = Regex.Match(footnoteContent, @"<h4 id=RA_Trigger>.*?</h4>.*?Examples\s*:\s*\n((?:>\s*.*?\n)*)", RegexOptions.Singleline);
                    if (triggerExamplesMatch.Success)
                    {
                        guide.TriggeredIndicatorExamples = ExtractBlockquoteListLines(triggerExamplesMatch.Groups[1].Value);
                    }
                }
            }

            if (!guide.AchievementCategories.SelectMany(c => c.Achievements).Any(a => a.Points > 0) && totalPointsFromSummary > 0)
            {
                var allAchs = guide.AchievementCategories.SelectMany(c => c.Achievements).ToList();
                if (allAchs.Any())
                {
                    int pointsPerAch = totalPointsFromSummary / allAchs.Count;
                    int remainder = totalPointsFromSummary % allAchs.Count;
                    for (int i = 0; i < allAchs.Count; i++)
                    {
                        allAchs[i].Points = pointsPerAch + (i < remainder ? 1 : 0);
                    }
                }
            }
            return guide;
        }

        private string ExtractBlockquoteListLines(string block)
        {
            var lines = block.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var cleanedLines = lines.Select(l => {
                var trimmed = l.Trim();
                if (trimmed.StartsWith("> -"))
                {
                    trimmed = trimmed.Substring(3).Trim();
                }
                else if (trimmed.StartsWith(">"))
                {
                    trimmed = trimmed.Substring(1).Trim();
                }
                // Strip markdown italics
                return Regex.Replace(trimmed, @"\*(.*?)\*", "$1");
            });
            return string.Join("\n", cleanedLines);
        }

        private static List<string> GetListItems(string sectionContent)
        {
            var content = Regex.Replace(sectionContent, @"<h4>.*?</h4>|<h5>.*?</h5>", "").Trim();
            return content.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(line => line.Trim().StartsWith("-") ? line.Trim().Substring(1).Trim() : line.Trim())
                          .Where(line => !string.IsNullOrWhiteSpace(line))
                          .ToList();
        }
    }
}