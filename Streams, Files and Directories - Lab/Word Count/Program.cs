using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Word_Count
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] text = await File.ReadAllLinesAsync("Input.txt");
            string words = await File.ReadAllTextAsync("words.txt");
            string[] splitedWords = words.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            SortedDictionary<string, int> result = new SortedDictionary<string, int>();

            for (int j = 0; j < text.Length; j++)
            {
                string[] splitedText = text[j]
                    .Split(new char[] { ' ', '.', ',', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < splitedWords.Length; i++)
                {
                    string wordInText = splitedWords[i].ToLower();

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
            foreach (var item in result
                .OrderByDescending(x => x.Value))
            {
                await File
                    .AppendAllTextAsync("Output.txt", $"{item.Key} - {item.Value} {Environment.NewLine}");
            }
        }
    }
}
