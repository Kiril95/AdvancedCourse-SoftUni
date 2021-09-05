using System;
using System.Dynamic;
using System.Linq;

namespace Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = ReadIntArray();
            int[,] matrix = new int[sizeMatrix[0], sizeMatrix[1]];
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] array = ReadIntArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = array[col];
                    sum += matrix[row, col];
                }
                
            }
            Console.WriteLine(sizeMatrix[0]);
            Console.WriteLine(sizeMatrix[1]);
            Console.WriteLine(sum);
        }

        private static int[] ReadIntArray()
        {
            return Console.ReadLine()
                .Split(new char[]{' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
