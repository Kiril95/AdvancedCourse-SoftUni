using System;
using System.Linq;

namespace Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = ReadIntArray();
            char[,] matrix = new char[sizeMatrix[0], sizeMatrix[1]];
            string snake = Console.ReadLine();
            //string tempSnake = snake;
            int count = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (snake.Length == count)
                        {
                            count = 0;
                        }

                        matrix[row, col] = snake[count++];
                        //tempSnake = tempSnake.Remove(0, 1);
                    }
                }
                else
                {
                    for (int i = matrix.GetLength(1) - 1; i >= 0; i--)
                    {
                        if (snake.Length == count)
                        {
                            count = 0;
                        }

                        matrix[row, i] = snake[count++];
                        //tempSnake = tempSnake.Remove(0, 1);
                    }
                }

            }
            PrintMatrix(sizeMatrix, matrix);

        }
        public static int[] ReadIntArray()
        {
            return Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
        public static void PrintMatrix(int[] matrixSizes, char[,] matrix)
        {
            for (int row = 0; row < matrixSizes[0]; row++)
            {
                for (int col = 0; col < matrixSizes[1]; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
