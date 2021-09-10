using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            FillMatrix(size, matrix);
            string[] coordinates = ReadStringArray();

            for (int i = 0; i < coordinates.Length; i++)
            {
                string[] subSplit = coordinates[i].Split(",").ToArray();
                int row = int.Parse(subSplit[0]);
                int col = int.Parse(subSplit[1]);
                int value = matrix[row, col];

                if (matrix[row, col] > 0)
                {
                    if (Validation(matrix, row - 1, col - 1) && matrix[row - 1, col - 1] > 0)
                    {
                        matrix[row - 1, col - 1] -= matrix[row, col];
                    }
                    
                    if (Validation(matrix, row - 1, col) && matrix[row - 1, col] > 0)
                    {
                        matrix[row - 1, col] -= matrix[row, col];
                    }
                    
                    if (Validation(matrix, row - 1, col + 1) && matrix[row - 1, col + 1] > 0)
                    {
                        matrix[row - 1, col + 1] -= matrix[row, col];
                    }
                    
                    if (Validation(matrix, row, col + 1) && matrix[row, col + 1] > 0)
                    {
                        matrix[row, col + 1] -= matrix[row, col];
                    }
                    
                    if (Validation(matrix, row + 1, col + 1) && matrix[row + 1, col + 1] > 0)
                    {
                        matrix[row + 1, col + 1] -= matrix[row, col];
                    }
                    
                    if (Validation(matrix, row + 1, col) && matrix[row + 1, col] > 0)
                    {
                        matrix[row + 1, col] -= matrix[row, col];
                    }
                    
                    if (Validation(matrix, row + 1, col - 1) && matrix[row + 1, col - 1] > 0)
                    {
                        matrix[row + 1, col - 1] -= matrix[row, col];
                    }
                    
                    if (Validation(matrix, row, col - 1) && matrix[row, col - 1] > 0)
                    {
                        matrix[row, col - 1] -= matrix[row, col];
                    }

                    matrix[row, col] = 0;
                }
            }

            IEnumerable<int> activeCells = matrix
                .OfType<int>()
                .Where(value => value > 0);

            Console.WriteLine($"Alive cells: {activeCells.Count()}");
            Console.WriteLine($"Sum: {activeCells.Sum()}");
            PrintMatrix(size,matrix);
        }
        public static int[] ReadIntArray()
        {
            return Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
        public static string[] ReadStringArray()
        {
            return Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
        }
        public static void PrintMatrix(int size, int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
        public static void FillMatrix(int size, int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] arr = ReadIntArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }
        }
        public static bool Validation(int[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}
