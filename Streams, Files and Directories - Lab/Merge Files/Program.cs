using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Merge_Files
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] text = await File.ReadAllLinesAsync("FileOne.txt");
            string[] text2 = await File.ReadAllLinesAsync("FileTwo.txt");
            SortedSet<string> res = new SortedSet<string>();

            foreach (var line in text)
            {
                res.Add(line);
            }

            foreach (var line in text2)
            {
                res.Add(line);
            }

            File.WriteAllLines("Output.txt", res);

        }
    }
}
