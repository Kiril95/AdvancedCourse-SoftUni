using System;
using System.Linq;

namespace Super_Mario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            char[][] lair = new char[size][];
            int startRow = -1;
            int startCol = -1;
            bool savedPrincess = false;
            FillMatrix(lair, size, ref startRow, ref startCol);

            while (lives > 0 && savedPrincess == false)
            {
                string[] operations = ReadStringArray();
                string direction = operations[0];
                int spawnRow = int.Parse(operations[1]);
                int spawnCol = int.Parse(operations[2]);
                lives--;
                lair[spawnRow][spawnCol] = 'B';
                lair[startRow][startCol] = '-';

                if (Validation(lair, startRow - 1, startCol) && direction == "W")
                {
                    startRow--;
                    CheckLair(lair, startRow, startCol, ref lives, ref savedPrincess);
                }

                else if (Validation(lair, startRow + 1, startCol) && direction == "S")
                {
                    startRow++;
                    CheckLair(lair, startRow, startCol, ref lives, ref savedPrincess);
                }

                else if (Validation(lair, startRow, startCol - 1) && direction == "A")
                {
                    startCol--;
                    CheckLair(lair, startRow, startCol, ref lives, ref savedPrincess);
                }

                else if (Validation(lair, startRow, startCol + 1) && direction == "D")
                {
                    startCol++;
                    CheckLair(lair, startRow, startCol, ref lives, ref savedPrincess);
                }
            }
            
            Console.WriteLine(savedPrincess == true
                ? $"Mario has successfully saved the princess! Lives left: {lives}"
                : $"Mario died at {startRow};{startCol}.");

            PrintMatrix(lair);
        }
        private static void CheckLair(char[][] lair, int startRow, int startCol, ref int lives, ref bool savedPrincess)
        {
            if (lair[startRow][startCol] == 'P')
            {
                lair[startRow][startCol] = '-';
                savedPrincess = true;
            }

            if (lives <= 0 && lair[startRow][startCol] != 'P')
            {
                lair[startRow][startCol] = 'X';
            }

            else if (lair[startRow][startCol] == 'B')
            {
                lives -= 2;
                if (lives <= 0)
                {
                    lair[startRow][startCol] = 'X';
                }
                else
                {
                    lair[startRow][startCol] = '-';
                }
            }
        }
        public static bool Validation(char[][] lair, int rowIdx, int colIdx)
        {
            if (rowIdx >= 0 && rowIdx < lair.Length &&
                colIdx >= 0 && colIdx < lair[rowIdx].Length)
            {
                return true;
            }

            return false;
        }
        private static void FillMatrix(char[][] lair, int size, ref int startRow, ref int startCol)
        {
            for (int row = 0; row < lair.Length; row++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                lair[row] = line;
                for (int col = 0; col < lair[row].Length; col++)
                {
                    if (lair[row][col] == 'M')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
        }
        private static void PrintMatrix(char[][] lair)
        {
            foreach (var row in lair)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
        public static string[] ReadStringArray()
        {
            return Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
        }
    }
}
