using System.Collections.Generic;
using System.Linq;

namespace RaGuideDesigner.Services
{
    // This static class provides a way to map between long platform names
    // (e.g., "PlayStation") and their common short names (e.g., "PS1").
    public static class PlatformMappingService
    {
        private static readonly Dictionary<string, string> _platformMap = new Dictionary<string, string>
        {
            // Full Name -> Short Name
            // Nintendo
            // Added Nintendo Wii to the platform list.
            { "Game Boy", "GB" }, { "Game Boy Color", "GBC" }, { "Game Boy Advance", "GBA" }, { "NES/Famicom", "NES" }, { "SNES/Super Famicom", "SNES" }, { "Nintendo 64", "N64" }, { "GameCube", "GC" }, { "Nintendo Wii", "Wii" }, { "Nintendo DS", "NDS" }, { "Nintendo DSi", "DSi" }, { "Pokemon Mini", "Pokemon Mini" }, { "Virtual Boy", "VB" },
            // Sony
            { "PlayStation", "PS1" }, { "PlayStation 2", "PS2" }, { "PlayStation Portable", "PSP" },
            // Sega
            { "SG-1000", "SG-1000" }, { "Master System", "Master System" }, { "Game Gear", "Game Gear" }, { "Genesis/Mega Drive", "Genesis" }, { "Sega CD", "Sega CD" }, { "32X", "32X" }, { "Saturn", "Saturn" }, { "Dreamcast", "Dreamcast" },
            // Atari
            { "Atari 2600", "Atari 2600" }, { "Atari 7800", "Atari 7800" }, { "Atari Jaguar", "Jaguar" }, { "Atari Jaguar CD", "Jaguar CD" }, { "Atari Lynx", "Lynx" },
            // NEC
            { "PC Engine/TurboGrafx-16", "PC Engine" }, { "PC Engine/TurboGrafx-CD", "PC-FX" }, { "PC-8000/8800", "PC-8800" },
            // SNK
            { "Neo Geo CD", "Neo Geo CD" }, { "Neo Geo Pocket", "NGP" },
            // Others
            { "3DO Interactive Multiplayer", "3DO" }, { "Amstrad CPC", "Amstrad CPC" }, { "Apple II", "Apple II" }, { "Arcade", "Arcade" }, { "Arcadia 2001", "Arcadia 2001" }, { "Arduboy", "Arduboy" }, { "ColecoVision", "ColecoVision" }, { "Elektor TV Games Computer", "Elektor TV" }, { "Fairchild Channel F", "Channel F" }, { "Intellivision", "Intellivision" }, { "Interton VC 4000", "VC 4000" }, { "Magnavox Odyssey 2", "Odyssey 2" }, { "Mega Duck", "Mega Duck" }, { "MSX", "MSX" }, { "Standalone", "Standalone" }, { "Uzebox", "Uzebox" }, { "Vectrex", "Vectrex" }, { "WASM-4", "WASM-4" }, { "Watara Supervision", "Supervision" }, { "WonderSwan", "WonderSwan" }
        };

        private static readonly List<string> _headers = new List<string>
        {
            "Nintendo", "Sony", "Sega", "Atari", "NEC", "SNK", "Others"
        };

        // Provides a pre-formatted list for the platform selection dropdown,
        // complete with group headers and indented items.
        public static List<string> GetGroupedPlatforms()
        {
            // Added Nintendo Wii to the grouped list.
            return new List<string>
            {
                "Nintendo", "  Game Boy", "  Game Boy Color", "  Game Boy Advance", "  NES/Famicom", "  SNES/Super Famicom", "  Nintendo 64", "  GameCube", "  Nintendo Wii", "  Nintendo DS", "  Nintendo DSi", "  Pokemon Mini", "  Virtual Boy",
                "Sony", "  PlayStation", "  PlayStation 2", "  PlayStation Portable",
                "Sega", "  SG-1000", "  Master System", "  Game Gear", "  Genesis/Mega Drive", "  Sega CD", "  32X", "  Saturn", "  Dreamcast",
                "Atari", "  Atari 2600", "  Atari 7800", "  Atari Jaguar", "  Atari Jaguar CD", "  Atari Lynx",
                "NEC", "  PC Engine/TurboGrafx-16", "  PC Engine/TurboGrafx-CD", "  PC-8000/8800",
                "SNK", "  Neo Geo CD", "  Neo Geo Pocket",
                "Others", "  3DO Interactive Multiplayer", "  Amstrad CPC", "  Apple II", "  Arcade", "  Arcadia 2001", "  Arduboy", "  ColecoVision", "  Elektor TV Games Computer", "  Fairchild Channel F", "  Intellivision", "  Interton VC 4000", "  Magnavox Odyssey 2", "  Mega Duck", "  MSX", "  Standalone", "  Uzebox", "  Vectrex", "  WASM-4", "  Watara Supervision", "  WonderSwan"
            };
        }

        public static bool IsHeader(string item)
        {
            return _headers.Contains(item);
        }

        public static string GetShortName(string fullName)
        {
            if (_platformMap.TryGetValue(fullName, out var shortName))
            {
                return shortName;
            }
            return fullName;
        }

        public static string GetFullName(string shortName)
        {
            var entry = _platformMap.FirstOrDefault(kvp => kvp.Value.Equals(shortName, System.StringComparison.OrdinalIgnoreCase));
            if (entry.Key != null)
            {
                return entry.Key;
            }
            return shortName;
        }
    }
}