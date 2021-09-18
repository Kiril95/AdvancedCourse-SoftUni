using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Even_Lines
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] text = await File.ReadAllLinesAsync("text.txt");
            int count = 0;

            for (int i = 0; i < text.Length; i++)
            {
                string current = text[i];

                if (count % 2 == 0)
                {
                    string[] reversed = current.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Reverse()
                        .ToArray();
                    string joined = string.Join(" ", reversed);
                    string replaced = Regex.Replace(joined, @"[^\w\d\s]", "@");

                    Console.WriteLine(replaced);
                }
                count++;

            }
        }
    }
}
