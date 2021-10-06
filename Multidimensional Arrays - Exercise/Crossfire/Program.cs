using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = ReadIntArray();
            List<List<int>> matrix = new List<List<int>>();
            FillMatrix(matrix, size[0], size[1]);

            string command = Console.ReadLine();

            while (command != "Nuke it from orbit")
            {
                int[] operations = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                int hitRow = operations[0];
                int hitCol = operations[1];
                int hitRadius = operations[2];

                DestroyCells(matrix, hitRow, hitCol, hitRadius);
                RemoveCells(matrix);
                
                command = Console.ReadLine();
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(List<List<int>> matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void RemoveCells(List<List<int>> matrix)
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                matrix[row] = matrix[row].Where(x => x > 0).ToList();

                if (matrix[row].Count < 1)
                {
                    matrix.RemoveAt(row);
                    row--;
                }
            }
        }

        private static void DestroyCells(List<List<int>> matrix, int hitRow, int hitCol, int hitRadius)
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                for (int col = 0; col < matrix[row].Count; col++)
                {
                    if (row == hitRow && Math.Abs(col - hitCol) <= hitRadius ||
                        col == hitCol && Math.Abs(row - hitRow) <= hitRadius)
                    {
                        matrix[row][col] = -1;
                    }
                }
            }
        }

        private static void FillMatrix(List<List<int>> matrix, int rows, int cols)
        {
            int currNumber = 1;

            for (int row = 0; row < rows; row++)
            {
                matrix.Add(new List<int>());

                for (int col = 0; col < cols; col++)
                {
                    matrix[row].Add(currNumber);
                    currNumber++;
                }
            }
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
