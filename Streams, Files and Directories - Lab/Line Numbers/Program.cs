using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Line_Numbers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] text = await File.ReadAllLinesAsync("Input.txt");

            for (int i = 0; i < text.Length; i++)
            {
                text[i] = $"{i + 1}. {text[i]}";
                //await File.WriteAllTextAsync("Output.txt", $"{i + 1}. {text[i]}");
            }

            await File.WriteAllLinesAsync("Output.txt", text);
        }
    }
}
