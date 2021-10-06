using System;
using System.Linq;

namespace Lego_Blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            string[][] first = new string[rows][];
            string[][] second = new string[rows][];

            FillDimensions(first, rows);
            FillDimensions(second, rows);
            ReverseJaggy(second);

            if (DoesItFit(first,second))
            {
                for (int row = 0; row < first.Length; row++)
                {
                    Console.WriteLine($"[{string.Join(", ", first[row].Concat(second[row]))}]");
                }
                
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {CountCells(first, second)}");
            }

        }

        private static object CountCells(string[][] first, string[][] second)
        {
            int cells = 0;

            for (int row = 0; row < first.Length; row++)
            {
                cells += first[row].Length + second[row].Length;
            }

            return cells;
        }

        private static bool DoesItFit(string[][] first, string[][] second)
        {
            for (int row = 1; row < first.Length; row++)
            {
                if (first[row].Length + second[row].Length != first[row - 1].Length + second[row - 1].Length)
                {
                    return false;
                }
            }
            return true;
        }

        private static void ReverseJaggy(string[][] second)
        {
            for (int row = 0; row < second.Length; row++)
            {
                Array.Reverse(second[row]);
            }
        }

        private static void FillDimensions(string[][] jaggy, int rows)
        {
            for (int row = 0; row < jaggy.Length; row++)
            {
                jaggy[row] = ReadStringArray();
            }
        }

        private static string[] ReadStringArray()
        {
            return Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  .ToArray();
        }
    }
}
