using System;
using System.Linq;

namespace The_Battle_of_The_Five_Armies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            char[][] battlefield = new char[size][];
            int startRow = -1;
            int startCol = -1;
            bool reachedMordor = false;
            FillMatrix(battlefield, size, ref startRow, ref startCol);

            while (armor > 0 && reachedMordor == false)
            {
                string[] operations = ReadStringArray();
                string direction = operations[0];
                int spawnRow = int.Parse(operations[1]);
                int spawnCol = int.Parse(operations[2]);
                armor--;
                battlefield[spawnRow][spawnCol] = 'O';
                battlefield[startRow][startCol] = '-';

                if (Validation(battlefield, startRow - 1, startCol) && direction == "up")
                {
                    startRow--;
                    CheckField(battlefield, startRow, startCol, ref armor, ref reachedMordor);
                }

                else if (Validation(battlefield, startRow + 1, startCol) && direction == "down")
                {
                    startRow++;
                    CheckField(battlefield, startRow, startCol, ref armor, ref reachedMordor);
                }

                else if (Validation(battlefield, startRow, startCol - 1) && direction == "left")
                {
                    startCol--;
                    CheckField(battlefield, startRow, startCol, ref armor, ref reachedMordor);
                }

                else if (Validation(battlefield, startRow, startCol + 1) && direction == "right")
                {
                    startCol++;
                    CheckField(battlefield, startRow, startCol, ref armor, ref reachedMordor);
                }
            }

            Console.WriteLine(reachedMordor == true
                ? $"The army managed to free the Middle World! Armor left: {armor}"
                : $"The army was defeated at {startRow};{startCol}.");

            PrintMatrix(battlefield);
        }
        private static void CheckField(char[][] battlefield, int startRow, int startCol, ref int armor, ref bool reachedMordor)
        {
            if (armor <= 0 && battlefield[startRow][startCol] != 'M')
            {
                battlefield[startRow][startCol] = 'X';
            }

            if (battlefield[startRow][startCol] == 'O')
            {
                armor -= 2;
                if (armor <= 0)
                {
                    battlefield[startRow][startCol] = 'X';
                }
                else
                {
                    battlefield[startRow][startCol] = '-';
                }
            }

            else if (battlefield[startRow][startCol] == 'M')
            {
                battlefield[startRow][startCol] = '-';
                reachedMordor = true;
            }
        }
        public static bool Validation(char[][] battlefield, int rowIdx, int colIdx)
        {
            if (rowIdx >= 0 && rowIdx < battlefield.Length &&
                colIdx >= 0 && colIdx < battlefield[rowIdx].Length)
            {
                return true;
            }

            return false;
        }
        private static void FillMatrix(char[][] battlefield, int size, ref int startRow, ref int startCol)
        {
            for (int row = 0; row < battlefield.Length; row++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                battlefield[row] = line;
                for (int col = 0; col < battlefield[row].Length; col++)
                {
                    if (battlefield[row][col] == 'A')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
        }
        private static void PrintMatrix(char[][] battlefield)
        {
            foreach (var row in battlefield)
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
