using System;
using System.Linq;
using System.Security.Claims;

namespace Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = ReadIntArray();
            int[,] matrix = new int[sizeMatrix[0], sizeMatrix[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] array = ReadIntArray();
           
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = array[col];
                }
           
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sum = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sum += matrix[row, col];

                }
                Console.WriteLine(sum);

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
