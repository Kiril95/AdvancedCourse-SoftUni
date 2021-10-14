using System;
using System.Linq;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[][] field = new char[size][];
            int startRow = -1;
            int startCol = -1;
            int flowersFound = 0;
            bool isLost = false;
            FillMatrix(field, size, ref startRow, ref startCol);

            string direction = Console.ReadLine();
            while (direction != "End")
            {
                field[startRow][startCol] = '.';

                if (Validation(field, startRow - 1, startCol) && direction == "up")
                {
                    startRow--;
                    CollectFlower(field, startRow, startCol, ref flowersFound);
                    BonusMove(field, ref startRow, ref startCol, direction, ref flowersFound);
                }

                else if (Validation(field, startRow + 1, startCol) && direction == "down")
                {
                    startRow++;
                    CollectFlower(field, startRow, startCol, ref flowersFound);
                    BonusMove(field, ref startRow, ref startCol, direction, ref flowersFound);
                }

                else if (Validation(field, startRow, startCol - 1) && direction == "left")
                {
                    startCol--;
                    CollectFlower(field, startRow, startCol, ref flowersFound);
                    BonusMove(field, ref startRow, ref startCol, direction, ref flowersFound);
                }

                else if (Validation(field, startRow, startCol + 1) && direction == "right")
                {
                    startCol++;
                    CollectFlower(field, startRow, startCol, ref flowersFound);
                    BonusMove(field, ref startRow, ref startCol, direction, ref flowersFound);
                }
                else
                {
                    isLost = true;
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                direction = Console.ReadLine();
            }

            if (flowersFound >= 5)
            {
                if (!isLost)
                {
                    field[startRow][startCol] = 'B';
                    Console.WriteLine($"Great job, the bee managed to pollinate {flowersFound} flowers!");
                }
                else
                {
                    Console.WriteLine($"Great job, the bee managed to pollinate {flowersFound} flowers!");
                }
            }
            else
            {
                if (!isLost)
                {
                    field[startRow][startCol] = 'B';
                    Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowersFound} flowers more");
                }
                else
                {
                    Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowersFound} flowers more");

                }
            }
            PrintMatrix(field);

        }
        private static void BonusMove(char[][] field, ref int startRow, ref int startCol, string direction, ref int flowersFound)
        {
            if (field[startRow][startCol] == 'O')
            {
                field[startRow][startCol] = '.';
                if (direction == "up")
                {
                    startRow--;
                    CollectFlower(field, startRow, startCol, ref flowersFound);
                }
                else if (direction == "down")
                {
                    startRow++;
                    CollectFlower(field, startRow, startCol, ref flowersFound);
                }
                else if (direction == "left")
                {
                    startCol--;
                    CollectFlower(field, startRow, startCol, ref flowersFound);
                }
                else if (direction == "right")
                {
                    startCol++;
                    CollectFlower(field, startRow, startCol, ref flowersFound);
                }
            }
        }
        private static void CollectFlower(char[][] field, int startRow, int startCol, ref int flowersFound)
        {
            if (field[startRow][startCol] == 'f')
            {
                flowersFound++;
                field[startRow][startCol] = '.';
            }
        }
        public static bool Validation(char[][] field, int rowIdx, int colIdx)
        {
            if (rowIdx >= 0 && rowIdx < field.Length &&
                colIdx >= 0 && colIdx < field[rowIdx].Length)
            {
                return true;
            }

            return false;
        }
        private static void FillMatrix(char[][] field, int size, ref int startRow, ref int startCol)
        {
            for (int row = 0; row < field.Length; row++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                field[row] = line;
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'B')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
        }
        private static void PrintMatrix(char[][] field)
        {
            foreach (var row in field)
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
