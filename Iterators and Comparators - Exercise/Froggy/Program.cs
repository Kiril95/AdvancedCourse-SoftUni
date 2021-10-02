using System;
using System.Linq;

namespace Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            Lake stones = new Lake(numbers);
            Console.WriteLine(string.Join(", ", stones));

        }
    }
}
