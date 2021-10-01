using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomStack<int> stack = new CustomStack<int>(new List<int>());

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] operations = command
                    .Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command.Contains("Push"))
                {
                    for (int i = 1; i < operations.Length; i++)
                    {
                        stack.Push(int.Parse(operations[i]));
                    }
                }
                else if (command.Contains("Pop"))
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (InvalidOperationException error)
                    {
                        Console.WriteLine(error.Message);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(stack);
            Console.WriteLine(stack);
        }
    }
}
