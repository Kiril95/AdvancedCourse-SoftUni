using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;

namespace Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] operations = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (operations[0] == 1)
                {
                    stack.Push(operations[1]);
                }

                else if (operations[0] == 2)
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }

                else if (operations[0] == 3 || operations[0] == 4)
                {
                    if (stack.Count > 0)
                    {
                        int[] array = stack.ToArray();

                        if (operations[0] == 3)
                        {
                            Console.WriteLine(array.Max());
                        }
                        else if (operations[0] == 4)
                        {
                            Console.WriteLine(array.Min());
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ",stack));

        }
    }
}
