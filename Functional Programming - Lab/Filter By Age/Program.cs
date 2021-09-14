using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> students = new Dictionary<string, int>();
            
            for (int i = 0; i < n; i++)
            {
                string[] operations = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = operations[0];
                int age = int.Parse(operations[1]);
                if (!students.ContainsKey(name))
                {
                    students.Add(name, age);
                }
            }

            string condition = Console.ReadLine();
            int filter = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();
            Func<int, int, bool> filtering = null;

            switch (condition)
            {
                case "younger":
                    filtering = (x, y) => x < y;
                    break;
                case "older":
                    filtering = (x, y) => x >= y;
                    break;
            }
            Printer(students, filtering, filter, format);

        }
        private static void Printer(Dictionary<string, int> students
            , Func<int, int, bool> filtering
            , int filter
            , string format)
        {
            if (format == "name")
            {
                foreach (var person in students
                    .Where(p => filtering(p.Value, filter)))
                {
                    Console.WriteLine(person.Key);
                }
            }

            else if (format == "age")
            {
                foreach (var person in students
                    .Where(p => filtering(p.Value, filter)))
                {
                    Console.WriteLine(person.Value);
                }
            }

            else if (format == "name age")
            {
                foreach (var person in students
                    .Where(p => filtering(p.Value, filter)))
                {
                    Console.WriteLine($"{person.Key} - {person.Value}");
                }
            }
        }
    }
}
