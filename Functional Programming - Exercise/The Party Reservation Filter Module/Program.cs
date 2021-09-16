using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> filters = new List<string>();
            string command = Console.ReadLine();

            while (command != "Print")
            {
                string[] operations = command.Split(";", StringSplitOptions.RemoveEmptyEntries);

                if (operations[0] == "Add filter")
                {
                    filters.Add($"{operations[1]} {operations[2]}");
                }
                else if (operations[0] == "Remove filter")
                {
                    if (filters.Contains($"{operations[1]} {operations[2]}"))
                    {
                        filters.Remove($"{operations[1]} {operations[2]}");
                    }

                }
                command = Console.ReadLine();
            }

            foreach (var item in filters)
            {
                string[] tokens = item.Split(' ');

                if (tokens[0] == "Starts")
                {
                    people = people.Where(p => !p.StartsWith(tokens[2])).ToList();
                }
                else if (tokens[0] == "Ends")
                {
                    people = people.Where(p => !p.EndsWith(tokens[2])).ToList();
                }
                else if (tokens[0] == "Length")
                {
                    people = people.Where(p => p.Length != int.Parse(tokens[1])).ToList();
                }
                else if (tokens[0] == "Contains")
                {
                    people = people.Where(p => !p.Contains(tokens[1])).ToList();
                }
            }

            if (people.Any())
            {
                Console.WriteLine(string.Join(" ", people));
            }

        }
    }
}
