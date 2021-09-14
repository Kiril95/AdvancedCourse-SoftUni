using System;
using System.Linq;
using System.Threading;

namespace Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<object> Print = s => Console.WriteLine(s);
            Func<string, bool> filter = s => char.IsUpper(s[0]);
            string[] text = Console.ReadLine()
                .Split(new char[] { ' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries);

            Print(string.Join(Environment.NewLine, text
                .Where(filter)));

        }
    }
}
