using System;
using System.Linq;

namespace Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            int primary = 0;
            int secondary = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] array = ReadIntArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = array[col];
                }
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (row == col)
                    {
                        primary += matrix[row, col];
                    }

                    if ((row + col) == (size - 1))
                    {
                        secondary += matrix[row, col];
                    }
                }
            }
            Console.WriteLine($"{Math.Abs(primary - secondary)}");

        }
        public static int[] ReadIntArray()
        {
            return Console.ReadLine()
                .Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
