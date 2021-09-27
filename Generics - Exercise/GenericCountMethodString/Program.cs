using System;
using System.Collections.Generic;

namespace GenericCountMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<string> boxes = new Box<string>(new List<string>());

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                boxes.Info.Add(line);
            }

            string element = Console.ReadLine();

            int result = boxes.CountGreaterValues(element);

            Console.WriteLine(result);
        }
    }
}
