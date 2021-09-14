using System;
using System.Linq;
using System.Threading.Channels;

namespace Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<object> Print = s => Console.WriteLine(s);
            Func<string, int> parsing = x => int.Parse(x);

            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parsing)
                .ToArray();

            Print(numbers.Length);
            Print(numbers.Sum());
            GC.Collect();
        }
    }
}
