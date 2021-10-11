using System;
using System.Collections.Generic;
using System.Linq;

namespace Warm_Winter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] forStacking = ReadIntArray();
            int[] forQueueing = ReadIntArray();

            Stack<int> hats = new Stack<int>(forStacking);
            Queue<int> scarfs = new Queue<int>(forQueueing);
            List<int> sets = new List<int>();

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int currentHat = hats.Peek();
                int currentScarf = scarfs.Peek();

                if (currentHat > currentScarf)
                {
                    int item = currentHat + currentScarf;
                    sets.Add(item);
                    hats.Pop();
                    scarfs.Dequeue();
                }
                else if (currentHat < currentScarf)
                {
                    hats.Pop();
                    continue;
                }
                else if (currentHat == currentScarf)
                {
                    scarfs.Dequeue();
                    hats.Push(hats.Pop() + 1);
                }

            }
            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ", sets));
        }
        private static int[] ReadIntArray()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
