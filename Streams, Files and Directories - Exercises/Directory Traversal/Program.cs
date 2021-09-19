using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Directory_Traversal
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string path = Console.ReadLine();
            string[] paths = Directory.GetFiles(path);
            Dictionary<string, List<FileInfo>> files = new Dictionary<string, List<FileInfo>>();

            foreach (var file in paths)
            {
                FileInfo info = new FileInfo(file);
                string extension = info.Extension;

                if (files.ContainsKey(extension))
                {
                    files[extension].Add(info);
                }
                else
                {
                    files[extension] = new List<FileInfo>();
                }
            }

            using (StreamWriter writer = new StreamWriter("C:\\Users\\Tolev\\Desktop\\report.txt"))
            {
                foreach (var item in files.OrderByDescending(k => k.Value.Count).ThenBy(name => name.Key))
                {
                    await writer.WriteLineAsync(item.Key);
                    foreach (var kvp in item.Value.OrderBy(x => Math.Ceiling((double)x.Length / 1024)))
                    {
                        await writer.WriteLineAsync($"--{kvp.Name} - {Math.Ceiling((double)kvp.Length / 1024)}kb");
                    }
                }
            }

        }
    }
}
