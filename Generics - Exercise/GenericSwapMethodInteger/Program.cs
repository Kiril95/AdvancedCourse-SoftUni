using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<int> boxes = new Box<int>(new List<int>());

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                boxes.Info.Add(number);
            }

            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            boxes.Swap(indexes[0], indexes[1]);
            Console.WriteLine(boxes);

        }
    }
}
