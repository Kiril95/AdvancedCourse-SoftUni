using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] operations = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> numbers = new Queue<int>();
            int toBePushed = operations[0];
            int toBePopped = operations[1];
            int toBeSearched = operations[2];

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < toBePushed; j++)
                {
                    numbers.Enqueue(nums[i]);
                    i++;
                }
            }

            for (int i = 0; i < toBePopped; i++)
            {
                numbers.Dequeue();
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }
            if (numbers.Contains(toBeSearched))
            {
                Console.WriteLine("true");
            }
            else
            {
                int[] array = numbers.ToArray();
                Console.WriteLine(array.Min());
            }

        }
    }
}
