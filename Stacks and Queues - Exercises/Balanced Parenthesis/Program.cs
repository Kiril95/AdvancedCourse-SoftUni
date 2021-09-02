using System;
using System.Collections.Generic;
using System.Linq;

namespace Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<string> brackets = new Stack<string>();

            bool isTrue = true;

            for (int i = 0; i < input.Length; i++)
            {
                string current = input[i].ToString();

                if (current == "{" || current == "(" || current == "[")
                {
                    brackets.Push(current);
                }

                else if (current == ")" || current == "}" || current == "]")
                {
                    if (brackets.Count <= 0)
                    {
                        isTrue = false;
                        break;
                    }
                    string previous = brackets.Peek();

                    if (current == "}" && previous == "{" || current == ")" && previous == "("
                                                          || current == "]" && previous == "[")
                    {
                        brackets.Pop();
                    }
                    else
                    {
                        isTrue = false;
                        break;
                    }

                }
            }
            //  {[()]}
            //  {[(])}
            //  { {[[(())]]} }

            if (isTrue)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }
    }
}
