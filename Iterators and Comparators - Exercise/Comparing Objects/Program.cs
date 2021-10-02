using System;
using System.Collections.Generic;
using Comparing_Objects;

namespace ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            int equal = 0;
            int different = 0;
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] operations = command.Split();
                people.Add(new Person(operations[0], int.Parse(operations[1]), operations[2]));
                command = Console.ReadLine();
            }

            int index = int.Parse(Console.ReadLine());
            Person person = people[index - 1];

            foreach (var element in people)
            {
                if (element.CompareTo(person) == 0)
                {
                    equal++;
                }
                else
                {
                    different++;
                }
            }

            Console.WriteLine(equal > 1
                ? $"{equal} {different} {equal + different}"
                : "No matches");
        }
    }
}
