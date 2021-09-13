using System;
using System.Collections.Generic;
using System.Linq;

namespace The_V_Logger
{
    class Program
    {
        public class Statistics
        {
            public SortedSet<string> Following { get; set; }
            public SortedSet<string> Followers { get; set; }

            public Statistics(SortedSet<string> following, SortedSet<string> followers)
            {
                Following = following;
                Followers = followers;
            }
        }
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, Statistics> register = new Dictionary<string, Statistics>();

            while (command != "Statistics")
            {
                string[] operations = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string vlogger = operations[0];

                if (operations[1] == "joined")
                {
                    if (!register.ContainsKey(vlogger))
                    {
                        register.Add(vlogger,
                        new Statistics(new SortedSet<string>(), new SortedSet<string>()));
                    }
                }
                else if (operations[1] == "followed")
                {
                    string secondVl = operations[2];

                    if (register.ContainsKey(vlogger) && register.ContainsKey(secondVl)
                              && vlogger != secondVl)
                    {
                        if (!register[vlogger].Following.Contains(secondVl))
                        {
                            register[vlogger].Following.Add(secondVl);
                            register[secondVl].Followers.Add(vlogger);
                        }
                    }
                }
                command = Console.ReadLine();

            }
            int place = 1;
            Console.WriteLine($"The V-Logger has a total of {register.Count} vloggers in its logs.");

            foreach (var item in register
                .OrderByDescending(x => x.Value.Followers.Count)
                .ThenBy(x => x.Value.Following.Count))
            {
                if (place == 1 && item.Value.Followers.Count > 0)
                {
                    Console.WriteLine($"{place}. {item.Key} : {item.Value.Followers.Count} " +
                                      $"followers, {item.Value.Following.Count} following");

                    foreach (var person in item.Value.Followers)
                    {
                        Console.WriteLine($"*  {person}");
                    }
                }
                else
                {
                    Console.WriteLine($"{place}. {item.Key} : {item.Value.Followers.Count} " +
                                      $"followers, {item.Value.Following.Count} following");
                }
                place++; 
            }
        }
    }
}
