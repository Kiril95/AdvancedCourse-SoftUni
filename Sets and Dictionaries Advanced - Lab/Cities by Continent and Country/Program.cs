using System;
using System.Collections.Generic;

namespace Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int times = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> info =
                new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < times; i++)
            {
                string[] operations = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = operations[0];
                string country = operations[1];
                string city = operations[2];

                if (info.ContainsKey(continent))
                {
                    if (info[continent].ContainsKey(country))
                    {
                        info[continent][country].Add(city);
                    }
                    else
                    {
                        info[continent].Add(country, new List<string>{ city });
                    }

                }
                else
                {
                    info.Add(continent, 
                     new Dictionary<string, List<string>> {{ country, new List<string>{ city }}});
                }

            }
            foreach (var item in info)
            {
                Console.WriteLine($"{item.Key}:");
                foreach (var kvp in item.Value)
                {
                    Console.WriteLine($"{kvp.Key} -> {string.Join(", ",kvp.Value)}");
                }

            }

        }
    }
}
