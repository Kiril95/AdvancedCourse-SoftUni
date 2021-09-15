using System;
using System.Linq;

namespace Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(new char[] {' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Func<string, bool> filter = x => x.Length <= num;

            Console.WriteLine(string.Join(Environment.NewLine, names.Where(filter)));
        }
    }
}
