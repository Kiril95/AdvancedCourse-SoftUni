using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            string[] command = ReadStringArray();
            int startRow = 0;
            int startCol = 0;
            FillMatrix(size, matrix, ref startRow, ref startCol);

            for (int i = 0; i < command.Length; i++)
            {
                string direction = command[i];

                if (Validation(matrix, startRow - 1, startCol) && direction == "up")
                {
                    startRow--;
                }
                else if (Validation(matrix, startRow + 1, startCol) && direction == "down")
                {
                    startRow++;
                }
                else if (Validation(matrix, startRow, startCol - 1) && direction == "left")
                {
                    startCol--;
                }
                else if (Validation(matrix, startRow, startCol + 1) && direction == "right")
                {
                    startCol++;
                }

                if (Validation(matrix, startRow, startCol))
                {
                    if (matrix[startRow, startCol] == 'c')
                    {
                        matrix[startRow, startCol] = '*';
                    }

                    else if (matrix[startRow, startCol] == 'e')
                    {
                        Console.WriteLine($"Game over! ({startRow}, {startCol})");
                        return;
                    }
                }
            }
            int counted = matrix.OfType<char>().Count(x => x == 'c');

            if (counted == 0)
            { 
                Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
            }
            else
            {
                Console.WriteLine($"{counted} coals left. ({startRow}, {startCol})");
            }

        }
        public static char[] ReadCharArray()
        {
            return Console.ReadLine()
                .Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();
        }
        public static string[] ReadStringArray()
        {
            return Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
        }
        public static void FillMatrix(int size, char[,] matrix, ref int startRow, ref int startCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] arr = ReadCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                    if (matrix[row, col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
        }
        public static bool Validation(char[,] matrix, int row, int col)
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
