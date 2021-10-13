using System;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = ReadIntArray();
            int[,] garden = new int[size[0], size[1]];

            string command = Console.ReadLine();
            while (command != "Bloom Bloom Plow")
            {
                string[] operations = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int spawnRow = int.Parse(operations[0]);
                int spawnCol = int.Parse(operations[1]);
                int flowerRow = 0;
                int flowerCol = 0;

                if (Validation(garden, spawnRow, spawnCol))
                {
                    flowerRow = spawnRow;
                    flowerCol = spawnCol;

                    for (int row = 0; row < garden.GetLength(0); row++)
                    {
                        for (int col = 0; col < garden.GetLength(1); col++)
                        {
                            if (row == flowerRow || col == flowerCol)
                            {
                                garden[row, col] += 1;
                            }

                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                command = Console.ReadLine();
            }

            PrintMatrix(garden);

        }
        public static bool Validation(int[,] garden, int row, int col)
        {
            if (row >= 0 && row < garden.GetLength(0) &&
                col >= 0 && col < garden.GetLength(1))
            {
                return true;
            }

            return false;
        }
        public static void PrintMatrix(int[,] garden)
        {

            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    Console.Write(garden[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
        private static int[] ReadIntArray()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
