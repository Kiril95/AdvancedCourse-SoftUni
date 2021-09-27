using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<string> boxes = new Box<string>(new List<string>());

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                boxes.Info.Add(line);
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
