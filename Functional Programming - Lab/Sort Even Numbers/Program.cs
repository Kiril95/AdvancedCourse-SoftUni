using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        { 
            int[] numbers = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToArray();

            Console.WriteLine(string.Join(", ", numbers));

        }
    }
}
