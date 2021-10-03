using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> sortSet = new SortedSet<Person>();
            HashSet<Person> hSet = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                Person newPerson = new Person(name, age);

                sortSet.Add(newPerson);
                hSet.Add(newPerson);
            }

            Console.WriteLine(sortSet.Count);
            Console.WriteLine(hSet.Count);
        }
    }
}
