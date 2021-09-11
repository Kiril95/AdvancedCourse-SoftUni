using System;
using System.Collections.Generic;

namespace Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int times = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < times; i++)
            {
                string[] operations = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in operations)
                {
                    if (!elements.Contains(item))
                    {
                        elements.Add(item);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", elements));

        }
    }
}
