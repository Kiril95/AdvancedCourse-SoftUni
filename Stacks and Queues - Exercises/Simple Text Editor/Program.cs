using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //string command = Console.ReadLine();
            StringBuilder result = new StringBuilder();
            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string[] operations = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (operations[0] == "1")
                {
                    string text = operations[1];
                    result = result.Append(text);
                    stack.Push(result.ToString());
                }
                else if (operations[0] == "2")
                {
                    int count = int.Parse(operations[1]);
                    result = result.Remove(result.Length - count, count);
                    stack.Push(result.ToString());
                }
                else if (operations[0] == "3")
                {
                    int idx = int.Parse(operations[1]);
                    Console.WriteLine(result[idx - 1]);
                }
                else if (operations[0] == "4")
                {
                    //string repl = stack.Peek();
                    if (stack.Count > 1)
                    {
                        stack.Pop();
                        result = new StringBuilder();
                        result.Append(stack.Peek());
                    }
                    else
                    {
                        stack.Pop();
                        result = new StringBuilder();
                    }

                }
                GC.Collect();
            }

        }
    }
}
