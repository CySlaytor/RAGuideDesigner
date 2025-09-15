using Newtonsoft.Json;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RaGuideDesigner.Models
{
    public interface IGuideItem
    {
        string DisplayText { get; }
    }

    public class ResourceLink
    {
        public string Text { get; set; } = "New Link";
        public string Url { get; set; } = "https://retroachievements.org";
    }

    public class Admonition
    {
        public string Type { get; set; } = "NOTE";
        public string Content { get; set; } = "New note content.";
        public override string ToString() => $"[{Type}] {Content.Substring(0, System.Math.Min(Content.Length, 50))}...";
    }

    public class WikiGuide
    {
        public string GameTitle { get; set; } = "Untitled Game";
        public string Platform { get; set; } = "";
        public string BannerImageUrl { get; set; } = "";
        public string MasteryIconUrl { get; set; } = "";
        public string IntroText { get; set; } = "This guide provides comprehensive details...";
        public string LeaderboardIntroText { get; set; } = "This section provides a detailed breakdown...";
        public string MeasuredIndicatorExamples { get; set; } = "";
        public string TriggeredIndicatorExamples { get; set; } = "";

        public BindingList<ResourceLink> Guides { get; set; } = new();
        public BindingList<ResourceLink> Playthroughs { get; set; } = new();

        public string GeneralAdviceTitle { get; set; } = "🧠 General Advice (Before Starting a New Game)";
        public string GeneralAdvice { get; set; } = "Always keep an eye out for supply crates...";

        public BindingList<Admonition> Admonitions { get; set; } = new();

        public BindingList<AchievementCategory> AchievementCategories { get; set; } = new();
        public BindingList<Leaderboard> Leaderboards { get; set; } = new();
        public BindingList<Credit> Credits { get; set; } = new();
    }

    public class AchievementCategory : IGuideItem
    {
        public string Title { get; set; } = "New Category";
        public string Icon { get; set; } = "🏆";
        public string Description { get; set; } = "";
        public string AdditionalNotes { get; set; } = "";
        public bool IsCollectible { get; set; } = false;
        public BindingList<Admonition> Admonitions { get; set; } = new();
        public BindingList<Achievement> Achievements { get; set; } = new();
        public string DisplayText => $"{Icon} {Title}";
    }

    public class CollectibleItem
    {
        public string Description { get; set; } = "";
        public string Url { get; set; } = "";
        public string UrlText { get; set; } = "";
        public int? ItemNumber { get; set; }
    }

    public class CollectibleGroup
    {
        public string Title { get; set; } = "New Group";
        public BindingList<CollectibleItem> Items { get; set; } = new();
        public override string ToString() => Title;
    }


    public class Achievement : IGuideItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = "Untitled Achievement";
        public string Description { get; set; } = "";
        public string BadgeUrl { get; set; } = "";
        public string GuidanceAndInsights { get; set; } = "";
        public string Type { get; set; } = "";
        public int Points { get; set; }
        public string DisplayText => Title;
        public BindingList<Admonition> Admonitions { get; set; } = new();

        public string ImageUrl { get; set; } = "";
        public string VideoWalkthroughUrl { get; set; } = "";
        public BindingList<string> FailConditions { get; set; } = new();
        public string TriggerIndicator { get; set; } = "";
        public string MeasuredIndicator { get; set; } = "";
        public string MiscNote { get; set; } = "";
        public string DevNote { get; set; } = "";

        [JsonIgnore]
        public string CollectibleIntro { get; set; } = "";
        [JsonIgnore]
        public BindingList<CollectibleGroup> CollectibleGroups { get; set; } = new();

        #region Collectible Parsing/Serialization
        private void ParseCollectibleItemContent(CollectibleItem item, string content)
        {
            var contentMatch = Regex.Match(content, @"^(.*?)\s*\[(.*?)\]\((.*?)\)$", RegexOptions.Singleline);
            if (contentMatch.Success)
            {
                item.Description = contentMatch.Groups[1].Value.Trim();
                item.UrlText = contentMatch.Groups[2].Value.Trim();
                item.Url = contentMatch.Groups[3].Value.Trim();
            }
            else
            {
                item.Description = content;
                item.UrlText = "";
                item.Url = "";
            }
        }

        public void ParseGuidanceAsCollectible()
        {
            CollectibleIntro = "";
            CollectibleGroups.Clear();

            if (string.IsNullOrWhiteSpace(GuidanceAndInsights)) return;

            var content = GuidanceAndInsights.Replace("<br>", "\n");

            var outroMatch = Regex.Match(content, @"\n\s*-\s*(?:~~)?\s*A \[Measured Indicator\].*?\) (.*?)s*(?:~~)?$", RegexOptions.Singleline);
            if (outroMatch.Success)
            {
                MeasuredIndicator = outroMatch.Groups[1].Value.Trim();
                content = content.Substring(0, outroMatch.Index).Trim();
            }

            var firstGroupMatch = Regex.Match(content, "<u><b>");
            string groupsBlock;
            if (firstGroupMatch.Success)
            {
                CollectibleIntro = content.Substring(0, firstGroupMatch.Index).Trim();
                groupsBlock = content.Substring(firstGroupMatch.Index).Trim();
            }
            else
            {
                CollectibleIntro = content.Trim();
                groupsBlock = string.Empty;
            }

            if (CollectibleIntro.StartsWith("- "))
            {
                CollectibleIntro = CollectibleIntro.Substring(2).Trim();
            }

            if (string.IsNullOrWhiteSpace(groupsBlock)) return;

            var groupChunks = Regex.Split(groupsBlock, @"(?=<u><b>)").Where(s => !string.IsNullOrWhiteSpace(s));

            foreach (var chunk in groupChunks)
            {
                var titleMatch = Regex.Match(chunk, @"^<u><b>(.*?)</b></u>");
                if (!titleMatch.Success) continue;

                var group = new CollectibleGroup { Title = titleMatch.Groups[1].Value.Trim() };
                string itemsContent = chunk.Substring(titleMatch.Length).Trim();

                if (Regex.IsMatch(itemsContent, @"^\s*<b>\d+"))
                {
                    var itemChunks = Regex.Split(itemsContent, @"(?=\s*<b>\d+\s*[-—⁃]\s*</b>)").Where(s => !string.IsNullOrWhiteSpace(s));
                    foreach (var itemChunk in itemChunks)
                    {
                        var item = new CollectibleItem();
                        var trimmedChunk = itemChunk.Trim();
                        var numberedMatch = Regex.Match(trimmedChunk, @"^<b>(\d+)\s*[-—⁃]\s*</b>\s*(.*)", RegexOptions.Singleline);
                        if (numberedMatch.Success)
                        {
                            item.ItemNumber = int.Parse(numberedMatch.Groups[1].Value);
                            var itemText = numberedMatch.Groups[2].Value.Trim();
                            ParseCollectibleItemContent(item, itemText);
                        }
                        else
                        {
                            ParseCollectibleItemContent(item, trimmedChunk);
                        }
                        group.Items.Add(item);
                    }
                }
                else if (!string.IsNullOrWhiteSpace(itemsContent))
                {
                    var item = new CollectibleItem();
                    ParseCollectibleItemContent(item, itemsContent);
                    group.Items.Add(item);
                }

                CollectibleGroups.Add(group);
            }
        }


        public string SerializeCollectibleGuidance()
        {
            // If the collectible data hasn't been parsed yet, but there's text, parse it now.
            // This makes the method self-correcting.
            if (!CollectibleGroups.Any() && !string.IsNullOrWhiteSpace(GuidanceAndInsights))
            {
                ParseGuidanceAsCollectible();
            }

            var sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(CollectibleIntro))
            {
                sb.Append($"- {CollectibleIntro.Replace("\n", "<br>")}");
            }

            foreach (var group in CollectibleGroups)
            {
                if (sb.Length > 0) sb.Append("<br><br>");
                sb.Append($"<u><b>{group.Title}</b></u><br>");
                var itemsSb = new StringBuilder();

                bool isNumbered = group.Items.Any(i => i.ItemNumber.HasValue) || group.Items.Count > 1;
                int currentNumber = 1;

                foreach (var item in group.Items)
                {
                    if (itemsSb.Length > 0) itemsSb.Append("<br>");

                    if (isNumbered)
                    {
                        int numberToDisplay = item.ItemNumber ?? currentNumber;
                        itemsSb.Append($"<b>{numberToDisplay} ⁃ </b> ");
                    }
                    itemsSb.Append(item.Description.Replace("\n", "<br>"));
                    if (!string.IsNullOrWhiteSpace(item.Url) && !string.IsNullOrWhiteSpace(item.UrlText))
                    {
                        itemsSb.Append($" [{item.UrlText}]({item.Url})");
                    }
                    currentNumber++;
                }
                sb.Append(itemsSb.ToString().Trim());
            }

            if (sb.Length > 0 && !string.IsNullOrWhiteSpace(MeasuredIndicator))
            {
                sb.Append("<br><br>");
                sb.Append($"- A [Measured Indicator](#RA_Measure) {MeasuredIndicator.Replace("\n", "<br>")}");
            }

            return sb.ToString();
        }
        #endregion
    }

    public class Leaderboard : IGuideItem
    {
        public string Title { get; set; } = "New Leaderboard";
        public string DisplayText => $"🥇 {Title}";
        public string Description { get; set; } = "";

        public BindingList<string> StartRequirements { get; set; } = new();
        public BindingList<string> CancelConditions { get; set; } = new();
        public BindingList<string> SubmitConditions { get; set; } = new();
        public BindingList<string> MeasuredValue { get; set; } = new();

        public string MiscNote { get; set; } = "";
        public string DevNote { get; set; } = "";
    }

    public class Credit : IGuideItem
    {
        public string Username { get; set; } = "Username";
        public string AvatarUrl { get; set; } = "https://media.retroachievements.org/UserPic/placeholder.png";
        public string Role { get; set; } = "🟉 Contributor";
        public string ContributionDetails { get; set; } = "Tested the...";
        public string DisplayText => $"👤 {Username}";
    }
}