using System;
using System.Linq;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[][] field = new char[size][];
            int startRow = -1;
            int startCol = -1;
            int foodQuantity = 0;
            bool wellFed = false;
            FillMatrix(field, size, ref startRow, ref startCol);

            while (foodQuantity < 10 && wellFed == false)
            {
                string direction = Console.ReadLine();
                field[startRow][startCol] = '.';

                if (Validation(field, startRow - 1, startCol) && direction == "up")
                {
                    startRow--;
                    GoUnderground(field, ref startRow, ref startCol);
                    Eat(field, startRow, startCol, ref foodQuantity);
                }

                else if (Validation(field, startRow + 1, startCol) && direction == "down")
                {
                    startRow++;
                    GoUnderground(field, ref startRow, ref startCol);
                    Eat(field, startRow, startCol, ref foodQuantity);
                }

                else if (Validation(field, startRow, startCol - 1) && direction == "left")
                {
                    startCol--;
                    GoUnderground(field, ref startRow, ref startCol);
                    Eat(field, startRow, startCol, ref foodQuantity);
                }

                else if (Validation(field, startRow, startCol + 1) && direction == "right")
                {
                    startCol++;
                    GoUnderground(field, ref startRow, ref startCol);
                    Eat(field, startRow, startCol, ref foodQuantity);
                }
                else
                {
                    break;
                }

                if (foodQuantity >= 10)
                {
                    field[startRow][startCol] = 'S';
                    wellFed = true;
                    break;
                }
                
            }
            Console.WriteLine(wellFed ? "You won! You fed the snake." : "Game over!");
            Console.WriteLine($"Food eaten: {foodQuantity}");
            PrintMatrix(field);

        }
        private static void GoUnderground(char[][] field, ref int startRow, ref int startCol)
        {
            if (field[startRow][startCol] == 'B')
            {
                field[startRow][startCol] = '.';
                for (int row = 0; row < field.Length; row++)
                {
                    for (int col = 0; col < field[row].Length; col++)
                    {
                        if (field[row][col] == 'B')
                        {
                            startRow = row;
                            startCol = col;
                            field[startRow][startCol] = '.';
                            break;
                        }
                    }
                }
            }
        }
        private static void Eat(char[][] field, int startRow, int startCol, ref int foodQuantity)
        {
            if (field[startRow][startCol] == '*')
            {
                foodQuantity++;
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
                    if (field[row][col] == 'S')
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
