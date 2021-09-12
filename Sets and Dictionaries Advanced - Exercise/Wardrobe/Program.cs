 using System;
 using System.Collections.Generic;

 namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int times = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe 
                = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < times; i++)
            {
                string[] first = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = first[0];
                string[] second = first[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in second)
                {
                    if (wardrobe.ContainsKey(color))
                    {
                        if (wardrobe[color].ContainsKey(item))
                        {
                            wardrobe[color][item]++;
                        }
                        else
                        {
                            wardrobe[color].Add(item, 1);
                        }
                    }
                    else
                    {
                        wardrobe.Add(color, new Dictionary<string, int>{{ item, 1 }});
                    }
                }
            }
            string[] searched = Console.ReadLine().Split();
            string searchedColor = searched[0];
            string searchedType = searched[1];

            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");

                foreach (var (key, value) in item.Value)
                {
                    if (item.Key == searchedColor && key == searchedType)
                    {
                        Console.WriteLine($"* {key} - {value} (found!)");
                        continue;
                    }

                    Console.WriteLine($"* {key} - {value}");
                }
            }
        }
    }
}
