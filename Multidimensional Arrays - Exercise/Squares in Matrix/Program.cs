using System;
using System.Linq;

namespace Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = ReadIntArray();
            string[,] matrix = new string[size[0], size[1]];
            int count = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = array[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] &&
                        matrix[row, col] == matrix[row + 1, col] &&
                        matrix[row + 1, col] == matrix[row + 1, col + 1] )
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
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
