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
            RaJsonRoot? raData = null;

            // Check if the JSON is an array or an object at the root.
            if (jsonContent.Trim().StartsWith("["))
            {
                // It's an array, deserialize into a list and take the first element.
                var raDataList = JsonConvert.DeserializeObject<List<RaJsonRoot>>(jsonContent);
                raData = raDataList?.FirstOrDefault();
            }
            else
            {
                // It's an object, deserialize directly.
                raData = JsonConvert.DeserializeObject<RaJsonRoot>(jsonContent);
            }


            if (raData == null) throw new InvalidDataException("The provided JSON file could not be parsed or was empty.");

            // Create a new guide and ONLY populate it with data from the JSON.
            // Let the MainForm handle merging this with a template.
            var guide = new WikiGuide
            {
                GameTitle = raData.Title ?? "Unknown Title",
                MasteryIconUrl = $"https://media.retroachievements.org{raData.ImageIcon}",
                // Clear the default lists that the constructor might have added.
                AchievementCategories = new(),
                Leaderboards = new()
            };

            var progressionCategory = new AchievementCategory { Title = "Progression", Icon = "🏆" };
            var challengesCategory = new AchievementCategory { Title = "Challenges", Icon = "🏆" };

            if (raData.Achievements != null)
            {
                foreach (var ach in raData.Achievements)
                {
                    var achievement = new Achievement
                    {
                        Id = ach.ID,
                        Title = ach.Title ?? "Untitled Achievement",
                        Description = ach.Description ?? string.Empty,
                        // Prioritize the direct BadgeURL if it exists, otherwise construct it.
                        BadgeUrl = !string.IsNullOrWhiteSpace(ach.BadgeURL)
                                   ? ach.BadgeURL
                                   : $"https://media.retroachievements.org/Badge/{ach.BadgeName ?? "000000"}.png",
                        Type = ach.Type ?? string.Empty,
                        Points = ach.Points
                    };

                    // Sort achievements based on their official RA type.
                    if (achievement.Type == "progression" || achievement.Type == "win_condition")
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
            if (raData.Leaderboards != null)
            {
                foreach (var lb in raData.Leaderboards)
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

        // Defines the expected structure for deserializing the RA JSON.
        // Updated to match the new JSON format (Achievements and Leaderboards at the root).
        public class RaJsonRoot
        {
            public string? Title { get; set; }
            public string? ImageIcon { get; set; } // Changed from ImageIconUrl
            public List<RaAchievement>? Achievements { get; set; } // Moved from RaSet
            public List<RaLeaderboard>? Leaderboards { get; set; } // New
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