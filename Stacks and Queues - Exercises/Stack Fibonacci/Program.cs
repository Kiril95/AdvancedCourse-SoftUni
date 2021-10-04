using System;
using System.Collections.Generic;

namespace Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Stack<long> stack = new Stack<long>();
            stack.Push(0);
            stack.Push(1);

            for (int i = 1; i < num; i++)
            {
                long first = stack.Pop();
                long second = stack.Pop();

                stack.Push(first);
                stack.Push(first + second);
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
