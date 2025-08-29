using Newtonsoft.Json;
using RaGuideDesigner.Models;
using System.IO;

namespace RaGuideDesigner.Services
{
    // Handles saving and loading the project's data model to and from a JSON file.
    public class ProjectService
    {
        public void Save(WikiGuide guide, string filePath)
        {
            var json = JsonConvert.SerializeObject(guide, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public WikiGuide? Load(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<WikiGuide>(json);
        }
    }
}