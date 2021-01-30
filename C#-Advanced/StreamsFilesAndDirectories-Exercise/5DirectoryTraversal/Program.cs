using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _5DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string currendDirectory = Directory.GetCurrentDirectory();
            string[] filesInput = Directory.GetFiles(currendDirectory);

            Dictionary<string, Dictionary<string, double>> files = new Dictionary<string, Dictionary<string, double>>();

            foreach (var file in filesInput)
            {
                FileInfo fileInfo = new FileInfo(file);

                string extension = fileInfo.Extension;

                if (!files.ContainsKey(extension))
                {
                    files.Add(extension, new Dictionary<string, double>());
                }
                long size = fileInfo.Length;
                double kbSize = Math.Round(size / 1024.0, 3);
                files[extension].Add(fileInfo.Name, kbSize);
            }

            Dictionary<string, Dictionary<string, double>> sortedFiles = files.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            List<string> info = new List<string>();

            using(StreamWriter writer = new StreamWriter("../../../report.txt"))
            {
                foreach (var ext in sortedFiles)
                {
                    info.Add(ext.Key);
                    foreach (var file in ext.Value.OrderBy(x=>x.Value))
                    {
                        info.Add($"--{file.Key} - {file.Value}kb");
                    }
                }
            }
            string desktopPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"report.txt");
            File.WriteAllLines(desktopPath, info);
            
        }
    }
}
