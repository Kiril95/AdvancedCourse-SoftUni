using System;

namespace Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split();
            Tuple<string, string> firstTuple = new Tuple<string, string>($"{line[0]} {line[1]}", $"{line[2]}");
            Console.WriteLine(firstTuple);

            line = Console.ReadLine().Split();
            Tuple<string, int> secondTuple = new Tuple<string, int>(line[0], int.Parse(line[1]));
            Console.WriteLine(secondTuple);

            line = Console.ReadLine().Split();
            Tuple<int, double> thirdTuple = new Tuple<int, double>(int.Parse(line[0]), double.Parse(line[1]));
            Console.WriteLine(thirdTuple);

        }
    }
}
