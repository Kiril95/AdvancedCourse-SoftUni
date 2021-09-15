using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string command = Console.ReadLine();
            Func<int[], int[]> add = x => Add(numbers);
            Func<int[], int[]> subtract = x => Subtract(numbers);
            Func<int[], int[]> multiply = x => Multiply(numbers);
            Action<int[]> print = i => Console.WriteLine(string.Join(" ", i));

            while (command != "end")
            {
                if (command == "add")
                {
                    add(numbers);
                }
                else if (command == "subtract")
                {
                    subtract(numbers);
                }
                else if (command == "multiply")
                {
                    multiply(numbers);
                }
                else if (command == "print")
                {
                    print(numbers);
                }

                command = Console.ReadLine();
            }

        }
        private static int[] Multiply(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] *= 2;
            }

            return numbers;
        }
        private static int[] Subtract(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i]--;
            }

            return numbers;
        }
        private static int[] Add(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i]++;
            }

            return numbers;
        }
    }
}
