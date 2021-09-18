using System;
using System.IO;
using System.Threading.Tasks;

namespace Odd_Lines
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamWriter writer = new StreamWriter("Output.txt"))
            {
                using (StreamReader reader = new StreamReader("Input.txt"))
                {
                    int current = 0;
                    string text = await reader.ReadLineAsync();

                    while (text != null)
                    {
                        if (current % 2 != 0)
                        {
                            await writer.WriteLineAsync(text);
                        }

                        current++;
                        text = await reader.ReadLineAsync();
                    }

                }
            }

        }
    }
}
