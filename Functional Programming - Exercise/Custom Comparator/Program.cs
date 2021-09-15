using System;
using System.Collections.Generic;
using System.Linq;

namespace Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEven = n => n % 2 == 0;

            Dictionary<bool, List<int>> numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .GroupBy(n => isEven(n))
                .OrderByDescending(x => x.Key) 
                .ToDictionary(x => x.Key, x => x.OrderBy(x => x).ToList());

            foreach (var items in numbers)
            {
                Console.Write(string.Join(" ", items.Value) + " ");
            }
        }
    }
}
