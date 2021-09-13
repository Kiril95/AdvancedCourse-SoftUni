using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> langWithPass = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> database =
                                    new Dictionary<string, Dictionary<string, int>>();
            string command = Console.ReadLine();

            while (command != "end of contests")
            {
                string[] operations = command.Split(":");
                string language = operations[0];
                string pass = operations[1];

                if (!langWithPass.ContainsKey(language))
                {
                    langWithPass.Add(language, pass);
                }
                command = Console.ReadLine();

            }
            command = Console.ReadLine();

            while (command != "end of submissions")
            {
                string[] operations2 = command.Split("=>");
                string language = operations2[0];
                string pass = operations2[1];
                string user = operations2[2];
                int points = int.Parse(operations2[3]);

                if (langWithPass.ContainsKey(language)
                   && langWithPass[language] == pass)
                {
                    if (!database.ContainsKey(user))
                    {
                        database.Add(user, new Dictionary<string, int> { { language, points } });
                    }

                    if (database[user].ContainsKey(language))
                    {
                        if (database[user][language] < points)
                        {
                            database[user][language] = points;
                        }
                    }

                    else
                    {
                        database[user].Add(language, points);
                    }
                }
                command = Console.ReadLine();

            }
            // var max = main.Values.Max();
            int best = 0;
            string bestUser = string.Empty;
            foreach (var student in database)
            {
                int sum = 0;
                foreach (var contest in student.Value)
                {
                    sum += contest.Value;
                }
                if (sum > best)
                {
                    bestUser = student.Key;
                    best = sum;
                }
            }

            Console.WriteLine($"Best candidate is {bestUser} with total {best} points.");
            Console.WriteLine("Ranking:");

            foreach (var item in database.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key);

                foreach (var kvp in item.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {kvp.Key} -> {kvp.Value}");
                }
            }
        }
    }
}
