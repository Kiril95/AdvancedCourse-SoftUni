using System;
using System.Linq;

namespace Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[][] jaggy = new int[size][];

            for (int i = 0; i < jaggy.Length; i++)
            {
                int[] arr = ReadIntArray();
                jaggy[i] = arr;
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] operations = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int rowIdx = int.Parse(operations[1]);
                int colIdx = int.Parse(operations[2]);
                int value = int.Parse(operations[3]);

                if (operations[0] == "Add" &&
                    rowIdx >= 0 && rowIdx < jaggy.Length &&
                    colIdx >= 0 && colIdx < jaggy[rowIdx].Length)
                {
                    jaggy[rowIdx][colIdx] += value;
                }

                else if (operations[0] == "Subtract" &&
                         rowIdx >= 0 && rowIdx < jaggy.Length &&
                         colIdx >= 0 && colIdx < jaggy[rowIdx].Length)
                {
                    jaggy[rowIdx][colIdx] -= value;
                }

                else
                {
                    Console.WriteLine("Invalid coordinates");
                }

                command = Console.ReadLine();
            }

            foreach (var item in jaggy)
            {
                Console.WriteLine(string.Join(" " ,item));
            }

        }
        private static int[] ReadIntArray()
        {
            return Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
