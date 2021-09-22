using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] time1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] time2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            DateTime date1 = new DateTime(int.Parse(time1[0]), int.Parse(time1[1]), int.Parse(time1[2]));
            DateTime date2 = new DateTime(int.Parse(time2[0]), int.Parse(time2[1]), int.Parse(time2[2]));

            Console.WriteLine(DateModifier.DifferenceBetweenTwoDates(date1, date2));
        }
    }
}
