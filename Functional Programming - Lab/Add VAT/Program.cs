using System;
using System.Linq;

namespace Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<object> Print = s => Console.WriteLine(s);
            double[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Print(string.Join(Environment.NewLine, numbers
                .Select(x => $"{x * 1.20:f2}")));

        }
    }
}
