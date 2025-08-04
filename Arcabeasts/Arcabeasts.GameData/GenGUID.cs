using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Arcabeasts.GameData
{
    public static class GenGuid
    {
        public static void InsertGuids(string filePath)
        {
            string content = File.ReadAllText(filePath);

            // Match Arcabeast objects without an Id assignment
            string pattern = @"(new\s+\w+Arcabeast\s*\{)([^}]*?)(?=\s*\})";

            var updatedContent = Regex.Replace(content, pattern, match =>
            {
                var block = match.Groups[0].Value;

                if (block.Contains("Id ="))
                    return match.Value; // skip if already has Id

                string guidLine = $"\n                Id = new Guid(\"{Guid.NewGuid()}\"),";
                return match.Groups[1].Value + guidLine + match.Groups[2].Value;
            });

            File.WriteAllText(filePath, updatedContent);
            Console.WriteLine("GUIDs inserted into ArcabeastDB.cs");
        }

        public static void Main()
        {
            string arcabeastDbPath = @"A:\DotNetApps\Arcabeasts\Arcabeasts\Arcabeasts.GameData\ArcabeastDB.cs";
            InsertGuids(arcabeastDbPath);
        }
    }
}
