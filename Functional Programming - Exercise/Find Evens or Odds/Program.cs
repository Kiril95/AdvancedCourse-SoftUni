using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<object> Print = s => Console.WriteLine(s);
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string command = Console.ReadLine();
            List<int> result = new List<int>();
            Predicate<int> even = x => x % 2 == 0;
            Predicate<int> odd = x => x % 2 != 0;

            result = Result(numbers, command, result, even, odd).ToList();
            Print(string.Join(" ", result));

        }
        private static List<int> Result(int[] numbers, string command, List<int> result,
                                        Predicate<int> even, Predicate<int> odd)
        {
            int start = numbers[0];
            int end = numbers[1];

            if (command == "odd")
            {
                for (int i = start; i <= end; i++)
                {
                    if (odd(i))
                    {
                        result.Add(i);
                    }
                }
            }
            else if (command == "even")
            {
                for (int i = start; i <= end; i++)
                {
                    if (even(i))
                    {
                        result.Add(i);
                    }
                }
            }

            return result;
        }
    }
}
