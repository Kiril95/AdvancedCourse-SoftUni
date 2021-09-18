using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Line_Numbers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] text = await File.ReadAllLinesAsync("text.txt");

            for (int i = 0; i < text.Length; i++)
            {
                string current = text[i];
                int letters = Regex.Matches(current, @"[A-Za-z]")
                    .OfType<Match>()
                    .Select(x => x.Value)
                    .ToArray()
                    .Count();

                int symbols = Regex.Matches(current, @"[^\w\d\s]")
                    .OfType<Match>()
                    .Select(x => x.Value)
                    .ToArray()
                    .Count();

                string forPrinting = $"Line {i + 1}:{current}({letters})({symbols}){Environment.NewLine}";
                await File.AppendAllTextAsync("Output.txt", forPrinting);

            }
        }
    }
}

