using System;
using System.Collections.Generic;
using System.Linq;

namespace Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();

            while (command != "Party!")
            {
                string[] operations = command.Split();
                Func<string, bool> filter = Filter(operations);

                if (operations[0] == "Remove")
                {
                    for (int i = 0; i < people.Count; i++)
                    {
                        if (filter(people[i]))
                        {
                            people.RemoveAt(i);
                            i--;
                        }
                    }
                }

                else if (operations[0] == "Double")
                {
                    for (int i = 0; i < people.Count; i++)
                    {
                        if (filter(people[i]))
                        {
                            people.Insert(i + 1, people[i]);
                            i++;
                        }
                    }
                }
                command = Console.ReadLine();

            }
            if (people.Any())
            {
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
        private static Func<string, bool> Filter(string[] operations)
        {
            if (operations[1] == "StartsWith")
            {
                return x => x.StartsWith(operations[2]);
            }

            else if (operations[1] == "EndsWith")
            {
                return x => x.EndsWith(operations[2]);
            }

            else if (operations[1] == "Length")
            {
                return x => x.Length == int.Parse(operations[2]);
            }

            return null;
        }
    }
}
