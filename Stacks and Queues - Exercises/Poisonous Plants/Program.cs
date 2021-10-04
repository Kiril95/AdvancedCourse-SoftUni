using System;
using System.Collections.Generic;
using System.Linq;

namespace Poisonous_Plants
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> plants = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            Stack<int> plantsIndexes = new Stack<int>();

            int daysCount = 0;
            int deathCount = 1;

            while (plants.Count > 0)
            {
                if (deathCount <= 0)
                {
                    break;
                }
                deathCount = 0;

                for (int i = 0; i < n - 1; i++)
                {
                    if (plants[i + 1] > plants[i])
                    {
                        plantsIndexes.Push(i + 1);

                        deathCount++;
                    }
                }

                for (int i = 0; i < deathCount; i++)
                {
                    plants.RemoveAt(plantsIndexes.Pop());
                }

                n = plants.Count;
                daysCount++;
            }

            Console.WriteLine(daysCount - 1);
        }
    }
}
