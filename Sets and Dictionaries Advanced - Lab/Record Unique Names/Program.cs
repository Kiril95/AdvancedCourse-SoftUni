using System;
using System.Collections.Generic;

namespace Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int times = int.Parse(Console.ReadLine());
            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < times; i++)
            {
                string name = Console.ReadLine();

                if (!set.Contains(name))
                {
                    set.Add(name);
                }
            }
            Console.WriteLine();
            Console.WriteLine(string.Join(Environment.NewLine, set));
        }
    }
}
