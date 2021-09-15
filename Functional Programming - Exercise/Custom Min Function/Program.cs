using System;
using System.Linq;

namespace Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<object> Print = s => Console.WriteLine(s);
            double[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            Func<double[], double> func = GetMin;

            Print(func(numbers));
        }
        private static double GetMin(double[] numbers)
        {
            double min = double.MaxValue;

            foreach (var num in numbers)
            {
                if (num < min)
                {
                    min = num;
                }
            }
            return min;
        }
    }
}
