using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(nums);
            string command = Console.ReadLine().ToUpper();

            while (command != "END")
            {
                string[] operations = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (operations[0] == "ADD")
                {
                    int first = int.Parse(operations[1]);
                    int second = int.Parse(operations[2]);
                    stack.Push(first);
                    stack.Push(second);

                }
                else if (operations[0] == "REMOVE")
                {
                    int n = int.Parse(operations[1]);

                    if (n < stack.Count)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                command = Console.ReadLine().ToUpper();
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
