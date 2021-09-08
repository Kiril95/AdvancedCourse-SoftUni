using System;
using System.Linq;

namespace Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = ReadIntArray();
            int[,] matrix = new int[sizeMatrix[0], sizeMatrix[1]];
            int max = int.MinValue;
            int[,] subMatrix = new int[3, 3];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] array = ReadIntArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = array[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + 
                              matrix[row, col + 2] + matrix[row + 1, col] +
                              matrix[row + 1, col + 1] +  matrix[row + 1, col + 2] +
                              matrix[row + 2, col] + matrix[row + 2, col + 1] +
                              matrix[row +2, col + 2];

                    if (sum > max)
                    {
                        max = sum;
                        subMatrix[0, 0] = matrix[row, col];
                        subMatrix[0, 1] = matrix[row, col + 1];
                        subMatrix[0, 2] = matrix[row, col + 2];
                        subMatrix[1, 0] = matrix[row + 1, col];
                        subMatrix[1, 1] = matrix[row + 1, col + 1];
                        subMatrix[1, 2] = matrix[row + 1, col + 2];
                        subMatrix[2, 0] = matrix[row + 2, col];
                        subMatrix[2, 1] = matrix[row + 2, col + 1];
                        subMatrix[2, 2] = matrix[row + 2, col + 2];

                    }
                }
            }
            Console.WriteLine($"Sum = {max}");
            Console.WriteLine($"{subMatrix[0, 0]} {subMatrix[0, 1]} {subMatrix[0, 2]}");
            Console.WriteLine($"{subMatrix[1, 0]} {subMatrix[1, 1]} {subMatrix[1, 2]}");
            Console.WriteLine($"{subMatrix[2, 0]} {subMatrix[2, 1]} {subMatrix[2, 2]}");

        }
        public static int[] ReadIntArray()
        {
            return Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
