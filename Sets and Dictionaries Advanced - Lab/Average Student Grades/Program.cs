using System;
using System.Collections.Generic;
using System.Linq;

namespace Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int times = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < times; i++)
            {
                string[] operations = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = operations[0];
                decimal grade = decimal.Parse(operations[1]);

                if (students.ContainsKey(name))
                {
                    students[name].Add(grade);
                }
                else
                {
                    students.Add(name, new List<decimal> { grade });
                }

            }
            foreach (var item in students)
            {
                Console.WriteLine($"{item.Key} -> " +
                $"{string.Join(" ", item.Value.Select(x => $"{x:f2}"))} (avg: {item.Value.Average():f2})");
            }

        }
    }
}
