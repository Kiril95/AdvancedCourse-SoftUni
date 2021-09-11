using System;
using System.Collections.Generic;
using System.Linq;

namespace Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> SorSet = new SortedSet<string>();
            HashSet<string> hSet = new HashSet<string>();
            int times = int.Parse(Console.ReadLine());

            for (int i = 0; i < times; i++)
            {
                string name = Console.ReadLine();

                hSet.Add(name);
                //SorSet.Add(name);
            }
            //if (SorSet.Any())
            //{
            //    Console.WriteLine(string.Join(Environment.NewLine, SorSet));
            //}
            if (hSet.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, hSet));
            }
        }
    }
}
