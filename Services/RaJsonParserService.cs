using Newtonsoft.Json;
using RaGuideDesigner.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RaGuideDesigner.Services
{
    public class RaJsonParserService
    {
        // Parses an official RetroAchievements JSON file to create a basic WikiGuide object.
        // It mainly extracts the game title, mastery icon, and the list of achievements,
        // automatically sorting them into "Progression" and "Challenges" categories based on their type.
        public WikiGuide Parse(string filePath)
        {
            var jsonContent = File.ReadAllText(filePath);

            var raData = JsonConvert.DeserializeObject<RaJsonRoot>(jsonContent);

            if (raData == null) throw new InvalidDataException("The provided JSON file could not be parsed or was empty.");

            // Create a new guide and ONLY populate it with data from the JSON.
            // Let the MainForm handle merging this with a template.
            var guide = new WikiGuide
            {
                GameTitle = raData.Title ?? "Unknown Title",
                MasteryIconUrl = raData.ImageIconUrl ?? "",
                // Clear the default lists that the constructor might have added.
                AchievementCategories = new(),
                Leaderboards = new()
            };

            var coreSet = raData.Sets?.FirstOrDefault(s => s.Type == "core") ?? raData.Sets?.FirstOrDefault();
            if (coreSet == null)
            {
                return guide; // Return guide with title/icon if no sets are found
            }


            var progressionCategory = new AchievementCategory { Title = "Progression", Icon = "🏆" };
            var challengesCategory = new AchievementCategory { Title = "Challenges", Icon = "🏆" };

            if (coreSet.Achievements != null)
            {
                foreach (var ach in coreSet.Achievements)
                {
                    var achievement = new Achievement
                    {
                        Id = ach.ID,
                        Title = ach.Title ?? "Untitled Achievement",
                        Description = ach.Description ?? string.Empty,
                        GuidanceAndInsights = ach.Description ?? string.Empty,
                        BadgeUrl = !string.IsNullOrWhiteSpace(ach.BadgeURL)
                                   ? ach.BadgeURL
                                   : $"https://media.retroachievements.org/Badge/{ach.BadgeName ?? "000000"}.png",
                        Type = ach.Type ?? string.Empty,
                        Points = ach.Points
                    };

                    if (achievement.Type.Equals("progression", StringComparison.OrdinalIgnoreCase))
                    {
                        progressionCategory.Achievements.Add(achievement);
                    }
                    else
                    {
                        challengesCategory.Achievements.Add(achievement);
                    }
                }
            }

            if (progressionCategory.Achievements.Count > 0) guide.AchievementCategories.Add(progressionCategory);
            if (challengesCategory.Achievements.Count > 0) guide.AchievementCategories.Add(challengesCategory);

            // Parse new Leaderboards section
            if (coreSet.Leaderboards != null)
            {
                foreach (var lb in coreSet.Leaderboards)
                {
                    var leaderboard = new Leaderboard
                    {
                        Title = lb.Title ?? "Untitled Leaderboard",
                        Description = lb.Description ?? string.Empty,
                    };
                    guide.Leaderboards.Add(leaderboard);
                }
            }

            return guide;
        }

        public class RaJsonRoot
        {
            public string? Title { get; set; }
            public string? ImageIconUrl { get; set; }
            public List<RaSet>? Sets { get; set; }
        }

        public class RaSet
        {
            public string? Type { get; set; }
            public List<RaAchievement>? Achievements { get; set; }
            public List<RaLeaderboard>? Leaderboards { get; set; }
        }

        public class RaAchievement
        {
            public int ID { get; set; }
            public string? Title { get; set; }
            public string? Description { get; set; }
            public string? BadgeName { get; set; }
            public string? BadgeURL { get; set; } // New direct URL property
            public string? Type { get; set; }
            public int Points { get; set; }
        }

        public class RaLeaderboard
        {
            public int ID { get; set; }
            public string? Title { get; set; }
            public string? Description { get; set; }
        }
    }
}