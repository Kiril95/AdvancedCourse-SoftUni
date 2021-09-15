using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray(); ;
            List<int> result = new List<int>();

            for (int i = 1; i <= num; i++)
            {
                result.Add(i);
            }

            for (int i = 0; i < dividers.Length; i++)
            {
                Func<int, bool> isDivisible = x => x % dividers[i] == 0;
                result = result.Where(isDivisible).ToList();
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
