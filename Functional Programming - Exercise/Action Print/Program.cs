using System;
using System.Linq;

namespace Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<object> Print = s => Console.WriteLine(s);
            string[] text = Console.ReadLine()
                .Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            Print(string.Join(Environment.NewLine, text));
        }
    }
}
