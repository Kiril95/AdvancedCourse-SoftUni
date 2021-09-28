using System;

namespace Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split();
            string town = line.Length == 5 ? $"{line[3]} {line[4]}" : line[3];
            Threeuple<string, string, string> firstTuple = new Threeuple<string, string, string>($"{line[0]} {line[1]}", $"{line[2]}", town);
            Console.WriteLine(firstTuple);

            line = Console.ReadLine().Split();
            Threeuple<string, int, bool> secondTuple = new Threeuple<string, int, bool>(line[0], int.Parse(line[1]), line[2] == "drunk" ? true : false);
            Console.WriteLine(secondTuple);

            line = Console.ReadLine().Split();
            Threeuple<string, double, string> thirdTuple = new Threeuple<string, double, string>(line[0], double.Parse(line[1]), line[2]);
            Console.WriteLine(thirdTuple);

        }
    }
}
