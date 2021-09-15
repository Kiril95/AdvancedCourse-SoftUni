using System;
using System.Linq;

namespace Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int num = int.Parse(Console.ReadLine());
            Array.Reverse(numbers);
            Func<int, bool> isDivisible = x => x % num != 0;

            Console.WriteLine(string.Join(" ", numbers.Where(isDivisible)));
        }
    }
}
