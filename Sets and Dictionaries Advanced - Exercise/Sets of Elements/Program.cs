using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = ReadIntArray();
            HashSet<double> main = new HashSet<double>();
            HashSet<double> secondary = new HashSet<double>();
            
            for (int i = 0; i < arr[0]; i++)
            {
                main.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < arr[1]; i++)
            {
                secondary.Add(int.Parse(Console.ReadLine()));
            }

            if (main.Any() && secondary.Any())
            {
                main.IntersectWith(secondary);
                Console.WriteLine(string.Join(" ", main));
            }
            
        }
        public static int[] ReadIntArray()
        {
            return Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
