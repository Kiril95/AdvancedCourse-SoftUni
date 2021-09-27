using System;
using System.Collections.Generic;

namespace GenericCountMethodDouble
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<double> boxes = new Box<double>(new List<double>());

            for (int i = 0; i < n; i++)
            {
                double number = double.Parse(Console.ReadLine());

                boxes.Info.Add(number);
            }

            double element = double.Parse(Console.ReadLine());

            double result = boxes.CountGreaterValues(element);

            Console.WriteLine(result);
        }
    }
}
