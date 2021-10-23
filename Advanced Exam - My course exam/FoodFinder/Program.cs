using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder
{
    class Program
    {
        static void Main(string[] args)
        { 
            string[] forQueueing = ReadStringArray();
            string[] forStacking = ReadStringArray();
            Dictionary<string, SortedSet<string>> words = new Dictionary<string, SortedSet<string>>()
            {
                {"pear", new SortedSet<string>()},
                {"flour", new SortedSet<string>()},
                {"pork", new SortedSet<string>()},
                {"olive", new SortedSet<string>()}
            };
            Queue<string> vowels = new Queue<string>(forQueueing);
            Stack<string> consonants = new Stack<string>(forStacking);
            List<string> result = new List<string>();
            int wordsFound = 0;

            while (consonants.Count > 0)
            {
                string currentVow = vowels.Peek();
                string currentCons = consonants.Peek();
                foreach (var item in words)
                {
                    if (item.Key.Contains(currentVow))
                    {
                        words[item.Key].Add(currentVow);
                    }
                    if (item.Key.Contains(currentCons))
                    {
                        words[item.Key].Add(currentCons);
                    }
                }
                vowels.Enqueue(vowels.Dequeue());
                consonants.Pop();

            }
            foreach (var word in words)
            {
                string current = word.Key;
                
                if (current == "pear")
                {
                    if (words[current].Contains("p") 
                        && words[current].Contains("e")
                        && words[current].Contains("a")
                        && words[current].Contains("r"))
                    {
                        result.Add(current);
                        wordsFound++;
                    }
                    
                }
                if (current == "flour")
                {
                    if (words[current].Contains("f") 
                        && words[current].Contains("l")
                        && words[current].Contains("o")
                        && words[current].Contains("u")
                        && words[current].Contains("r"))
                    {
                        result.Add(current);
                        wordsFound++;
                    }
                    
                }
                if (current == "pork")
                {
                    if (words[current].Contains("p") 
                        && words[current].Contains("o")
                        && words[current].Contains("r")
                        && words[current].Contains("k"))
                    {
                        result.Add(current);
                        wordsFound++;
                    }
                    
                }
                if (current == "olive")
                {
                    if (words[current].Contains("o")
                        && words[current].Contains("l")
                        && words[current].Contains("i")
                        && words[current].Contains("v")
                        && words[current].Contains("e"))
                    {
                        result.Add(current);
                        wordsFound++;
                    }
                }
            }
            GC.Collect();

            Console.WriteLine($"Words found: {wordsFound}");
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
        private static string[] ReadStringArray()
        {
            return Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
        }
    }
}