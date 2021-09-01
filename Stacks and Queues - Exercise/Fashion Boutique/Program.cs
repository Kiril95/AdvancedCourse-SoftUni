using System;
using System.Collections.Generic;
using System.Linq;

namespace Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] basket = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int capacity = int.Parse(Console.ReadLine());
            Stack<int> clothes = new Stack<int>(basket);

            int count = 0;
            int sum = 0;

            while (clothes.Count > 0)
            {
                if (sum + clothes.Peek() <= capacity)
                {
                    sum += clothes.Pop();
                }
                else
                {
                    count++;
                    sum = 0;
                }

            }
            Console.WriteLine(count + 1);
        }
    }
}
