using RaGuideDesigner.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RaGuideDesigner.Services
{
    public class MarkdownGenerationService
    {
        // A helper method to build a formatted list for a section.
        // It handles the title and ensures items are properly line-broken.
        private void BuildListSection(StringBuilder sb, string title, BindingList<string> items)
        {
            if (items.Any())
            {
                if (sb.Length > 0) sb.Append("<br><br>");
                // No line break after the H4 tag, add a space for the list item
                sb.Append($"<h4>{title}</h4> ");
                // Join items with <br>, but also trim junk characters from each item first.
                var listContent = string.Join(" <br> ", items.Select(item => $"- {item.Replace("\n", "<br>").TrimEnd('|', '\\', ' ')}"));
                sb.Append(listContent);
            }
        }

        // This is the main engine that constructs the entire Markdown guide from the WikiGuide data model.
        // It assembles the document section by section: header, table of contents, achievements, leaderboards, and credits.
        public string Generate(WikiGuide guide)
        {
            var sb = new StringBuilder();
            var platformShortName = PlatformMappingService.GetShortName(guide.Platform);

            // Header
            sb.AppendLine($"# **Retro Achievements Guide** <br> 🔶 ***{guide.GameTitle}*** <sub><sup> ({platformShortName}) </sup></sub>");
            sb.AppendLine();
            sb.AppendLine("<p align=\"center\">");
            sb.AppendLine($"  <img width=\"600\" height=\"280\" src=\"{guide.BannerImageUrl}\">");
            sb.AppendLine("</p>");
            sb.AppendLine();
            sb.AppendLine("---");
            sb.AppendLine();
            sb.AppendLine(guide.IntroText);
            sb.AppendLine();

            // TOC
            sb.AppendLine("<h3 id=ToC> 📑 Table of Contents</h3>");
            sb.AppendLine();
            sb.AppendLine("- 💎 **[Achievement Guide](#AchievementGuide)**");
            foreach (var category in guide.AchievementCategories)
            {
                string categoryId = category.Title.Replace(" ", "_").Replace("/", "");
                sb.AppendLine($"    - {category.Icon} *[{category.Title}](#{categoryId})*");
            }
            if (guide.Leaderboards.Any()) sb.AppendLine("- 🥇 **[Leaderboard Guide](#LeaderboardGuide)**");
            if (guide.Credits.Any()) sb.AppendLine("- 📜 **[Credits](#Credits)**");
            sb.AppendLine("- ✏️ **[Footnotes](#Footnotes)**");
            sb.AppendLine();

            // Achievement Guide Section
            sb.AppendLine("<h1 id=AchievementGuide>");
            sb.AppendLine("    💎 Achievement Guide");
            sb.AppendLine("</h1>");
            sb.AppendLine();
            sb.AppendLine($"<img align=\"left\" width=\"96\" height=\"96\" src=\"{guide.MasteryIconUrl}\" alt=\"{guide.GameTitle} - RetroAchievements Mastery Icon\">");
            sb.AppendLine();
            int totalAchievements = guide.AchievementCategories.Sum(c => c.Achievements.Count);
            int totalPoints = guide.AchievementCategories.Sum(c => c.Achievements.Sum(a => a.Points));
            sb.AppendLine("```");
            sb.AppendLine($"Set consists of {totalAchievements} achievements worth {totalPoints} points");
            sb.AppendLine();
            sb.AppendLine("Set released on DD MMMM YYYY");
            sb.AppendLine("```");
            sb.AppendLine();

            // Walkthroughs & Resources
            sb.AppendLine("<h3 id=WalkthroughsResources>");
            sb.AppendLine("    📜 Walkthroughs & Resources");
            sb.AppendLine("</h3>");
            sb.AppendLine();

            if (guide.Guides.Any())
            {
                sb.AppendLine("#### 📚 Guides & Walkthroughs");
                foreach (var link in guide.Guides)
                {
                    sb.AppendLine($"- **[{link.Text}]({link.Url})**");
                }
                sb.AppendLine();
            }

            if (guide.Playthroughs.Any())
            {
                sb.AppendLine("#### 🎮 Playthroughs & Longplays");
                foreach (var link in guide.Playthroughs)
                {
                    sb.AppendLine($"- **[{link.Text}]({link.Url})**");
                }
                sb.AppendLine();
            }

            if (!string.IsNullOrWhiteSpace(guide.GeneralAdvice))
            {
                sb.AppendLine($"### {guide.GeneralAdviceTitle}");
                sb.AppendLine();
                sb.AppendLine(guide.GeneralAdvice);
                sb.AppendLine();
            }

            if (guide.Admonitions.Any())
            {
                bool first = true;
                foreach (var note in guide.Admonitions)
                {
                    if (!first) sb.AppendLine();
                    sb.AppendLine($"> [!{note.Type}]");
                    var contentLines = note.Content.Replace("\r\n", "\n").Split('\n');
                    for (int i = 0; i < contentLines.Length; i++)
                    {
                        var line = contentLines[i];
                        // Two spaces at the end of a line within a blockquote creates a hard line break (<br>) in GitHub Markdown
                        if (i < contentLines.Length - 1 && !string.IsNullOrWhiteSpace(line) && !line.EndsWith("  "))
                        {
                            sb.AppendLine($"> {line}  ");
                        }
                        else
                        {
                            sb.AppendLine($"> {line}");
                        }
                    }
                    first = false;
                }
                sb.AppendLine();
            }

            // Categories & Achievements
            foreach (var category in guide.AchievementCategories)
            {
                string categoryId = category.Title.Replace(" ", "_").Replace("/", "");
                int categoryPoints = category.Achievements.Sum(a => a.Points);
                sb.AppendLine("---");
                sb.AppendLine();
                sb.AppendLine($"<h1 id={categoryId}>");
                sb.AppendLine($"    {category.Icon} {category.Title} <i><sub><sup>({category.Achievements.Count} achievements - {categoryPoints} points)</sup></sub></i>");
                sb.AppendLine("</h1>");
                sb.AppendLine();
                if (!string.IsNullOrWhiteSpace(category.Description))
                {
                    sb.AppendLine(category.Description.Replace("\n", "<br>"));
                    sb.AppendLine();
                }

                if (category.Admonitions.Any())
                {
                    bool first = true;
                    foreach (var note in category.Admonitions)
                    {
                        if (!first) sb.AppendLine();
                        sb.AppendLine($"> [!{note.Type}]");
                        var contentLines = note.Content.Replace("\r\n", "\n").Split('\n');
                        for (int i = 0; i < contentLines.Length; i++)
                        {
                            var line = contentLines[i];
                            // Two spaces at the end of a line within a blockquote creates a hard line break (<br>) in GitHub Markdown
                            if (i < contentLines.Length - 1 && !string.IsNullOrWhiteSpace(line) && !line.EndsWith("  "))
                            {
                                sb.AppendLine($"> {line}  ");
                            }
                            else
                            {
                                sb.AppendLine($"> {line}");
                            }
                        }
                        first = false;
                    }
                    sb.AppendLine();
                }

                if (!string.IsNullOrWhiteSpace(category.AdditionalNotes))
                {
                    var processedNotes = ProcessBlockquotesForHardBreaks(category.AdditionalNotes);
                    sb.AppendLine(processedNotes);
                    sb.AppendLine();
                }

                sb.AppendLine($"### {category.Title} Achievement List");
                sb.AppendLine();
                sb.AppendLine("| Title | Guidance & Insights |");
                sb.AppendLine("|:---:|---|");
                foreach (var ach in category.Achievements)
                {
                    var cellContent = BuildAchievementGuidanceCell(ach, category);
                    string finalCellText = cellContent.Replace("|", "\\|");
                    sb.AppendLine($"| <h3 id={ach.Id}>**{ach.Title}**</h3> ![Achievement badge icon]({ach.BadgeUrl} \"Achievement badge icon\") | {finalCellText} |");
                }
                sb.AppendLine();
                sb.AppendLine($"🔗 [Back to Table of Contents](#ToC)");
                sb.AppendLine();
                sb.AppendLine($"🔗 [Back to Top of Achievement Category](#{categoryId})");
                sb.AppendLine();
            }

            // Leaderboard Guide Section
            if (guide.Leaderboards.Any())
            {
                sb.AppendLine("---");
                sb.AppendLine();
                sb.AppendLine("<h1 id=LeaderboardGuide>");
                sb.AppendLine("    🥇 Leaderboard Guide ");
                sb.AppendLine("</h1>");
                sb.AppendLine();

                if (!string.IsNullOrWhiteSpace(guide.LeaderboardIntroText))
                {
                    sb.AppendLine(guide.LeaderboardIntroText);
                    sb.AppendLine();
                }

                sb.AppendLine("### Leaderboard List");
                sb.AppendLine();
                sb.AppendLine("| Title | Guidance & Insights |");
                sb.AppendLine("|:---:|---|");
                foreach (var lb in guide.Leaderboards)
                {
                    var cellContent = new StringBuilder();
                    if (!string.IsNullOrWhiteSpace(lb.Description))
                    {
                        var descriptionLines = lb.Description.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        if (descriptionLines.Any())
                        {
                            var formattedDescription = string.Join("<br>", descriptionLines.Select(line => $"- {line.Trim()}"));
                            cellContent.Append(formattedDescription);
                        }
                    }

                    BuildListSection(cellContent, "Start Requirements", lb.StartRequirements);
                    BuildListSection(cellContent, "Cancel Conditions", lb.CancelConditions);
                    BuildListSection(cellContent, "Submit Conditions", lb.SubmitConditions);
                    BuildListSection(cellContent, "Measured Value", lb.MeasuredValue);

                    var notesContent = new StringBuilder();
                    if (!string.IsNullOrWhiteSpace(lb.MiscNote))
                    {
                        notesContent.Append($" <sub> **Misc note ⁃** *{lb.MiscNote.Replace("\n", "<br>")}* </sub>");
                    }
                    if (!string.IsNullOrWhiteSpace(lb.DevNote))
                    {
                        if (notesContent.Length > 0) notesContent.Append("<br>");
                        notesContent.Append($" <sub> **Dev note ⁃** *{lb.DevNote.Replace("\n", "<br>")}* </sub>");
                    }
                    if (notesContent.Length > 0)
                    {
                        if (cellContent.Length > 0) cellContent.Append("<br><br>");
                        cellContent.Append(notesContent);
                    }

                    string tempCellText = cellContent.ToString();
                    while (tempCellText.EndsWith(" ") || tempCellText.EndsWith("<br>"))
                    {
                        if (tempCellText.EndsWith("<br>"))
                        {
                            tempCellText = tempCellText.Substring(0, tempCellText.Length - 4);
                        }
                        else
                        {
                            tempCellText = tempCellText.TrimEnd();
                        }
                    }

                    string finalCellText = tempCellText.Replace("|", "\\|");
                    sb.AppendLine($"| <h3 id=LB_{lb.Title.Replace(" ", "")}>**{lb.Title}**</h3> | {finalCellText} |");
                }
                sb.AppendLine();
                sb.AppendLine($"🔗 [Back to Table of Contents](#ToC)");
                sb.AppendLine();
                sb.AppendLine($"🔗 [Back to Top of Leaderboard Guide](#LeaderboardGuide)");
                sb.AppendLine();
            }

            // Credits Section
            if (guide.Credits.Any())
            {
                sb.AppendLine("---");
                sb.AppendLine();
                sb.AppendLine("<h1 id=Credits>");
                sb.AppendLine("    📜 Credits");
                sb.AppendLine("</h1>");
                sb.AppendLine();
                sb.AppendLine("| RA-User | Role |");
                sb.AppendLine("|:---:|---|");
                foreach (var credit in guide.Credits)
                {
                    string details = "";
                    if (!string.IsNullOrWhiteSpace(credit.ContributionDetails))
                    {
                        var lines = credit.ContributionDetails.Replace("\r\n", "\n").Split('\n');
                        var formattedLines = lines.Where(l => !string.IsNullOrWhiteSpace(l))
                                                  .Select(l => $"- {l.Trim()}");
                        details = string.Join("<br>", formattedLines);
                    }

                    string formattedRole = credit.Role;
                    if (!string.IsNullOrWhiteSpace(credit.Role))
                    {
                        var roleParts = credit.Role.Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries)
                                                  .Select(p => p.Trim());

                        var formattedParts = new List<string>();
                        bool isFirst = true;
                        foreach (var part in roleParts)
                        {
                            if (isFirst)
                            {
                                int firstSpaceIndex = part.IndexOf(' ');
                                if (firstSpaceIndex > 0)
                                {
                                    string emoji = part.Substring(0, firstSpaceIndex).Trim();
                                    string mainRoleText = part.Substring(firstSpaceIndex + 1).Trim();
                                    formattedParts.Add($"{emoji} *{mainRoleText}*");
                                }
                                else
                                {
                                    formattedParts.Add($"*{part}*");
                                }
                                isFirst = false;
                            }
                            else
                            {
                                formattedParts.Add($"*{part}*");
                            }
                        }
                        formattedRole = string.Join(" \\| ", formattedParts);
                    }

                    var roleAndDetails = new StringBuilder($"<b> {formattedRole} </b>");
                    if (!string.IsNullOrWhiteSpace(details))
                    {
                        roleAndDetails.Append($" <br><br> {details}");
                    }

                    sb.AppendLine($"| <h4>[{credit.Username}](https://retroachievements.org/user/{credit.Username})</h4> <img src=\"{credit.AvatarUrl}\" alt=\"RA-User Avatar Image\" width=\"96\" height=\"96\"> | {roleAndDetails} |");
                }
                sb.AppendLine();
            }

            // Footnotes Section
            if (!string.IsNullOrWhiteSpace(guide.MeasuredIndicatorExamples) || !string.IsNullOrWhiteSpace(guide.TriggeredIndicatorExamples))
            {
                sb.AppendLine("<h1 id=Footnotes>");
                sb.AppendLine("    ✏️ Footnotes");
                sb.AppendLine("</h1>");
                sb.AppendLine();

                if (!string.IsNullOrWhiteSpace(guide.MeasuredIndicatorExamples))
                {
                    sb.AppendLine("<h4 id=RA_Measure> • Measured Indicator </h4>");
                    sb.AppendLine();
                    sb.AppendLine("An indicator displayed by the RetroAchievements overlay, often used to track specific progress within an achievement.");
                    sb.AppendLine("> **Examples**: ");
                    var lines = guide.MeasuredIndicatorExamples.Replace("\r\n", "\n").Split('\n');
                    foreach (var line in lines.Where(l => !string.IsNullOrWhiteSpace(l)))
                    {
                        sb.AppendLine($"> - *{line.Trim().TrimStart('-').Trim()}* ");
                    }
                    sb.AppendLine();
                }

                if (!string.IsNullOrWhiteSpace(guide.TriggeredIndicatorExamples))
                {
                    if (!string.IsNullOrWhiteSpace(guide.MeasuredIndicatorExamples)) sb.Append("<br>");
                    sb.AppendLine("<h4 id=RA_Trigger> • Triggered Indicator </h4>");
                    sb.AppendLine();
                    sb.AppendLine("An indicator displayed by the RetroAchievements overlay, typically used to show when a challenge achievement is available for unlocking or when it is currently active. If this indicator disappears before the achievement unlocks, it often signals a failure, indicating that a retry is necessary.");
                    sb.AppendLine("> **Examples**: ");
                    var lines = guide.TriggeredIndicatorExamples.Replace("\r\n", "\n").Split('\n');
                    foreach (var line in lines.Where(l => !string.IsNullOrWhiteSpace(l)))
                    {
                        sb.AppendLine($"> - {line.Trim().TrimStart('-').Trim()}");
                    }
                    sb.AppendLine();
                }
            }

            return sb.ToString();
        }

        private string BuildAchievementGuidanceCell(Achievement ach, AchievementCategory parentCategory)
        {
            if (parentCategory.IsCollectible)
            {
                string guidance = ach.SerializeCollectibleGuidance();
                if (string.IsNullOrWhiteSpace(ach.MeasuredIndicator))
                {
                    if (guidance.Length > 0)
                    {
                        guidance += "<br><br>- ~~A [Measured Indicator](#RA_Measure)~~";
                    }
                }
                return guidance;
            }

            var mainParts = new List<string>();
            bool isProgression = parentCategory.Title.Equals("Progression", StringComparison.OrdinalIgnoreCase);

            // --- Part 1: Main Guidance, Image, & Video ---
            var guidancePart = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(ach.GuidanceAndInsights))
            {
                if (isProgression)
                {
                    var guidanceLines = ach.GuidanceAndInsights.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    if (guidanceLines.Any())
                    {
                        var formattedGuidance = string.Join("<br>", guidanceLines.Select(line => $"- {line.Trim()}"));
                        guidancePart.Append(formattedGuidance);
                    }
                }
                else
                {
                    string formattedGuidance = ach.GuidanceAndInsights.Replace("\n", "<br>");
                    guidancePart.Append(formattedGuidance);
                }
            }
            if (!isProgression && !string.IsNullOrWhiteSpace(ach.ImageUrl))
            {
                if (guidancePart.Length > 0) guidancePart.Append("<br>");
                guidancePart.Append($"![Achievement Hint Image]({ach.ImageUrl})");
            }
            if (!isProgression && !string.IsNullOrWhiteSpace(ach.VideoWalkthroughUrl))
            {
                if (guidancePart.Length > 0) guidancePart.Append("<br> ");
                guidancePart.Append($"[▶️ Watch Video Walkthrough]({ach.VideoWalkthroughUrl})");
            }
            if (guidancePart.Length > 0) mainParts.Add(guidancePart.ToString());

            // --- Part 2: Fail Conditions & Tracking ---
            if (!isProgression)
            {
                var advancedPart = new StringBuilder();
                bool hasFailConditions = ach.FailConditions.Any();
                bool hasTrackingInfo = !string.IsNullOrWhiteSpace(ach.TriggerIndicator) || !string.IsNullOrWhiteSpace(ach.MeasuredIndicator);

                if (parentCategory.IsSimple)
                {
                    if (hasFailConditions)
                    {
                        advancedPart.Append("<h4>Fail Conditions</h4>");
                        var conditions = ach.FailConditions.Select(c => $"- {c.Replace("\n", "<br>")}").ToList();
                        advancedPart.Append(string.Join(" <br> ", conditions));
                    }
                    if (hasTrackingInfo)
                    {
                        if (advancedPart.Length > 0) advancedPart.Append(" ");
                        var trackingLines = new List<string>();
                        if (!string.IsNullOrWhiteSpace(ach.TriggerIndicator))
                        {
                            trackingLines.Add($"- A [Trigger Indicator](#RA_Trigger) {ach.TriggerIndicator.Replace("\n", "<br>")}");
                        }
                        if (!string.IsNullOrWhiteSpace(ach.MeasuredIndicator))
                        {
                            trackingLines.Add($"- A [Measured Indicator](#RA_Measure) {ach.MeasuredIndicator.Replace("\n", "<br>")}");
                        }
                        advancedPart.Append($"<h4>Achievement Tracking</h4> {string.Join(" <br> ", trackingLines)}");
                    }
                }
                else
                {
                    if (hasFailConditions)
                    {
                        advancedPart.Append("<h4>Fail Conditions</h4>");
                        var conditions = ach.FailConditions.Select(c => $"- {c.Replace("\n", "<br>")}").ToList();
                        advancedPart.Append(string.Join(" <br> ", conditions));
                    }
                    else
                    {
                        advancedPart.Append("<h4>~~Fail Conditions~~</h4>");
                    }
                    advancedPart.Append(" ");
                    if (hasTrackingInfo)
                    {
                        var trackingLines = new List<string>();
                        if (!string.IsNullOrWhiteSpace(ach.TriggerIndicator))
                        {
                            trackingLines.Add($"- A [Trigger Indicator](#RA_Trigger) {ach.TriggerIndicator.Replace("\n", "<br>")}");
                        }
                        if (!string.IsNullOrWhiteSpace(ach.MeasuredIndicator))
                        {
                            trackingLines.Add($"- A [Measured Indicator](#RA_Measure) {ach.MeasuredIndicator.Replace("\n", "<br>")}");
                        }
                        advancedPart.Append($"<h4>Achievement Tracking</h4> {string.Join(" <br> ", trackingLines)}");
                    }
                    else
                    {
                        advancedPart.Append("<h4>~~Achievement Tracking~~</h4>");
                    }
                }
                if (advancedPart.Length > 0)
                {
                    mainParts.Add(advancedPart.ToString());
                }
            }

            // --- Part 3: Admonitions ---
            if (ach.Admonitions.Any())
            {
                var admonitionPart = new StringBuilder();
                bool first = true;
                foreach (var note in ach.Admonitions)
                {
                    if (!first) admonitionPart.Append("<br>");
                    admonitionPart.Append($"> [!{note.Type}]<br>");
                    var contentLines = note.Content.Replace("\r\n", "\n").Split('\n');
                    foreach (var line in contentLines)
                    {
                        admonitionPart.Append($"> {line}<br>");
                    }
                    first = false;
                }
                mainParts.Add(admonitionPart.ToString().TrimEnd('<', 'b', 'r', '>'));
            }

            // --- Assembly of Main Content ---
            var cellBuilder = new StringBuilder(string.Join("<br><br>", mainParts));

            bool isWinCondition = ach.Type.Equals("win", StringComparison.OrdinalIgnoreCase) ||
                                  ach.Type.Equals("win_condition", StringComparison.OrdinalIgnoreCase);

            if (isWinCondition)
            {
                // Add the separator only if there is existing content in the cell
                if (cellBuilder.Length > 0)
                {
                    cellBuilder.Append("<br><br>");
                }
                cellBuilder.Append("- This achievement counts as the *win* condition for beating the game.");
            }

            // --- Part 4: Notes (with custom append logic) ---
            var notesPart = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(ach.MiscNote))
            {
                notesPart.Append($" <sub> **Misc note ⁃** *{ach.MiscNote.Replace("\n", "<br>")}* </sub>");
            }
            if (!string.IsNullOrWhiteSpace(ach.DevNote))
            {
                if (notesPart.Length > 0) notesPart.Append("<br>");
                notesPart.Append($" <sub> **Dev note ⁃** *{ach.DevNote.Replace("\n", "<br>")}* </sub>");
            }

            if (notesPart.Length > 0)
            {
                bool hasRealContentBeforeNotes = !string.IsNullOrWhiteSpace(ach.GuidanceAndInsights)
                                                 || !string.IsNullOrWhiteSpace(ach.VideoWalkthroughUrl)
                                                 || ach.FailConditions.Any()
                                                 || !string.IsNullOrWhiteSpace(ach.TriggerIndicator)
                                                 || !string.IsNullOrWhiteSpace(ach.MeasuredIndicator)
                                                 || ach.Admonitions.Any()
                                                 || isWinCondition; // Also consider the win condition text as "real content"

                if (cellBuilder.Length > 0)
                {
                    if (hasRealContentBeforeNotes)
                    {
                        cellBuilder.Append("<br><br>"); // Use a large separator if there was real content.
                    }
                    else
                    {
                        cellBuilder.Append("<br>"); // Use a small separator if there was only empty header text.
                    }
                }
                cellBuilder.Append(notesPart.ToString());
            }
            return cellBuilder.ToString();
        }

        // Ensures that blockquotes in Markdown get hard line breaks (`  \n`) between lines.
        // This is important because standard Markdown collapses single newlines inside blockquotes.
        private string ProcessBlockquotesForHardBreaks(string markdownBlock)
        {
            if (string.IsNullOrEmpty(markdownBlock)) return string.Empty;

            var lines = markdownBlock.Replace("\r\n", "\n").Split('\n');
            var resultBuilder = new StringBuilder();

            for (int i = 0; i < lines.Length; i++)
            {
                string currentLine = lines[i];

                if (currentLine.TrimStart().StartsWith(">"))
                {
                    bool nextLineContinuesBlock = (i + 1 < lines.Length) && lines[i + 1].TrimStart().StartsWith(">");
                    bool hasContent = !string.IsNullOrWhiteSpace(currentLine.TrimStart().Substring(1));

                    if (nextLineContinuesBlock && hasContent)
                    {
                        resultBuilder.AppendLine(currentLine + "  ");
                    }
                    else
                    {
                        resultBuilder.AppendLine(currentLine);
                    }
                }
                else
                {
                    resultBuilder.AppendLine(currentLine);
                }
            }

            return resultBuilder.ToString().TrimEnd();
        }
    }
}