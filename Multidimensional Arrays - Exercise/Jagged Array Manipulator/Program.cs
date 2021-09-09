using System;
using System.Linq;

namespace Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jaggy = new double[rows][];

            for (int i = 0; i < jaggy.Length; i++)
            {
                jaggy[i] = ReadDoubleArray();
            }

            for (int row = 0; row < jaggy.Length - 1; row++)
            {
                if (jaggy[row].Length == jaggy[row + 1].Length)
                {
                    for (int col = 0; col < jaggy[row].Length; col++)
                    {
                        jaggy[row][col] *= 2;
                        jaggy[row + 1][col] *= 2;

                    }
                }
                else
                {
                    for (int col = 0; col < jaggy[row].Length; col++)
                    {
                        jaggy[row][col] /= 2;
                    }

                    for (int col = 0; col < jaggy[row + 1].Length; col++)
                    {
                        jaggy[row + 1][col] /= 2;
                    }
                }

            }
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] operations = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int rowIdx = int.Parse(operations[1]);
                int colIdx = int.Parse(operations[2]);
                double value = double.Parse(operations[3]);

                if (operations[0] == "Add" && Validation(jaggy, rowIdx, colIdx))
                {
                    jaggy[rowIdx][colIdx] += value;
                }

                else if (operations[0] == "Subtract" && Validation(jaggy, rowIdx, colIdx))
                {
                    jaggy[rowIdx][colIdx] -= value;
                }

                command = Console.ReadLine();
            }

            foreach (var item in jaggy)
            {
                Console.WriteLine(string.Join(" ", item));
            }

        }
        public static double[] ReadDoubleArray()
        {
            return Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
        }
        public static bool Validation(double[][] jaggy, int rowIdx, int colIdx)
        {
            if (rowIdx >= 0 && rowIdx < jaggy.Length &&
                colIdx >= 0 && colIdx < jaggy[rowIdx].Length)
            {
                return true;
            }

            return false;
        }
    }
}
