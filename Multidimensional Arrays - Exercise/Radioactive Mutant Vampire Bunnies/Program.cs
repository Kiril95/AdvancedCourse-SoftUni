using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = ReadIntArray();
            int playerRow = -1;
            int playerCol = -1;
            char[,] matrix = new char[sizeMatrix[0], sizeMatrix[1]];
            FillMatrix(sizeMatrix, matrix, ref playerRow, ref playerCol);
            string command = Console.ReadLine();
            bool isWon = false;
            bool isDead = false;

            foreach (var item in command)
            {
                int tempPlayerRow = playerRow;
                int tempPlayerCol = playerCol;
                
                if (item == 'U')
                {
                    tempPlayerRow--;
                }
                else if (item == 'D')
                {
                    tempPlayerRow++;
                }
                else if (item == 'L')
                {
                    tempPlayerCol--;
                }
                else if (item == 'R')
                {
                    tempPlayerCol++;
                }

                matrix[playerRow, playerCol] = '.';
                isWon = !IndividualValidation(matrix,tempPlayerCol, tempPlayerRow, playerRow, playerCol);

                if (!isWon)
                {
                    if (matrix[tempPlayerRow, tempPlayerCol] == '.')
                    {
                        matrix[tempPlayerRow, tempPlayerCol] = 'P';
                    }
                    else if (matrix[tempPlayerRow, tempPlayerCol] == 'B')
                    {
                        isDead = true;
                    }

                    playerRow = tempPlayerRow;
                    playerCol = tempPlayerCol;
                }

                List<int[]> bunnyIdx = new List<int[]>();
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == 'B')
                        {
                            bunnyIdx.Add(new[] { i, j });
                        }
                    }
                }
                BunnyBussiness(bunnyIdx, matrix);

                if (matrix[playerRow, playerCol] == 'B')
                {
                    isDead = true;
                }

                if (isWon || isDead)
                {
                    break;
                }

            }
            PrintMatrix(matrix);
            Console.WriteLine(isWon ? $"won: {playerRow} {playerCol}" : $"dead: {playerRow} {playerCol}");

        }
        public static int[] ReadIntArray()
        {
            return Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
        public static void FillMatrix(int[] sizeMatrix, char[,] matrix, ref int playerRow, ref int playerCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }
        public static bool IndividualValidation(char[,] matrix, int row, int col, int rows, int cols)
        {
            if (row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }

            return false;
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
        public static void BunnyBussiness(List<int[]> bunnyIdx, char[,] matrix)
        {
            foreach (var rabbit in bunnyIdx)
            {
                int row = rabbit[0];
                int col = rabbit[1];

                if (Validation(matrix, row - 1, col))
                {
                    matrix[row - 1, col] = 'B';
                }
                if (Validation(matrix, row, col - 1))
                {
                    matrix[row, col - 1] = 'B';
                }
                if (Validation(matrix, row, col + 1))
                {
                    matrix[row, col + 1] = 'B';
                }
                if (Validation(matrix, row + 1, col))
                {
                    matrix[row + 1, col] = 'B';
                }
            }
        }
        public static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }

        }
    }
}
