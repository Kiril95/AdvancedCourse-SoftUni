using System;
using System.Collections.Generic;

namespace Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].ToString() == "(")
                {
                    stack.Push(i);
                }

                else if (input[i].ToString() == ")")
                {
                    int first = stack.Pop();
                    int end = i;

                    string subs = input.Substring(first, end - first + 1);
                    Console.WriteLine(subs);
                }

            }
        }
    }
}
