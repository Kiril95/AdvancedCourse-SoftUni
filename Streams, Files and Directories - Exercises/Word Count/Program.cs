using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Word_Count
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] text = await File.ReadAllLinesAsync("text.txt");
            string[] words = await File.ReadAllLinesAsync("words.txt");
            Dictionary<string, int> result = new Dictionary<string, int>();

            for (int j = 0; j < words.Length; j++)
            {
                string wordInText = words[j].ToLower();

                for (int i = 0; i < text.Length; i++)
                {
                    string[] splitedText = text[i]
                        .Split(new char[] { ' ', '.', ',', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int k = 0; k < splitedText.Length; k++)
                    {
                        string word = splitedText[k].ToLower();

                        if (wordInText == word)
                        {
                            if (result.ContainsKey(word))
                            {
                                result[word]++;
                            }
                            else
                            {
                                result.Add(word, 1);
                            }
                        }
                    }
                }
            }
            foreach (var item in result)
            {
                await File.AppendAllTextAsync("actualResult.txt", $"{item.Key} - {item.Value} {Environment.NewLine}");
            }

        }
    }
}
