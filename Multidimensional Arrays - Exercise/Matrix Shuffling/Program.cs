using System;
using System.Linq;

namespace Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = ReadIntArray();
            string[,] matrix = new string[sizeMatrix[0], sizeMatrix[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = array[col];
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] operations = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command.Contains("swap") && operations.Count() == 5)
                {
                    int row1 = int.Parse(operations[1]);
                    int col1 = int.Parse(operations[2]);
                    int row2 = int.Parse(operations[3]);
                    int col2 = int.Parse(operations[4]);

                    if (row1 >= 0 && row1 < matrix.GetLength(0) &&
                        col1 >= 0 && col1 < matrix.GetLength(1) &&
                        row2 >= 0 && row2 < matrix.GetLength(0) &&
                        col2 >= 0 && col2 < matrix.GetLength(1))
                    {
                        // Swap using tuples
                        (matrix[row1, col1], matrix[row2, col2]) = (matrix[row2, col2], matrix[row1, col1]);

                        //int temp = matrix[row1, col1];
                        //matrix[row1, col1] = matrix[row2, col2];
                        //matrix[row2, col2] = temp;

                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                Console.Write(matrix[i, j] + " ");
                            }

                            Console.WriteLine();
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                command = Console.ReadLine();
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
