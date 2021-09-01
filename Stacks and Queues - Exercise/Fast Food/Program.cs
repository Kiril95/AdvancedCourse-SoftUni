using System;
using System.Collections.Generic;
using System.Linq;

namespace Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            int[] array = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> orders = new Queue<int>(array);
            Console.WriteLine(orders.Max());

            while (orders.Count > 0)
            {
                if (orders.Peek() <= food)
                {
                    food -= orders.Dequeue();
                }
                else
                {
                    break;
                }

            }
            if (orders.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ",orders)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }

        }
    }
}
