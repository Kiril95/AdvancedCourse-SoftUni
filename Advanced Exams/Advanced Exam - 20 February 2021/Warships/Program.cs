using System;
using System.Linq;

namespace Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);
            string[][] battlefield = new string[size][];
            int firstPlayerShips = 0;
            int secondPlayerShips = 0;
            int destroyedShips = 0;
            bool gameOver = false;
            FillMatrix(battlefield, ref firstPlayerShips, ref secondPlayerShips);

            for (int i = 0; i < commands.Length; i++)
            {
                if (firstPlayerShips <= 0 || secondPlayerShips <= 0)
                {
                    gameOver = true;
                    break;
                }
                int row = 0;
                int col = 0;
                string[] subSplit = commands[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                bool check1 = int.TryParse(subSplit[0], out row);
                bool check2 = int.TryParse(subSplit[1], out col);

                if (Validation(battlefield, row, col))
                {
                    ShipsOperations(battlefield, row, col, ref firstPlayerShips, ref secondPlayerShips, ref destroyedShips);
                    
                    if (battlefield[row][col] == "#")
                    {
                        DetonateAdjacentFields(battlefield, ref firstPlayerShips, ref secondPlayerShips, row, col, ref destroyedShips);
                    }
                }
            }

            if (secondPlayerShips <= 0 || gameOver)
            {
                Console.WriteLine($"Player One has won the game! {destroyedShips} ships have been sunk in the battle.");
            }
            else if (firstPlayerShips <= 0 || gameOver)
            {
                Console.WriteLine($"Player Two has won the game! {destroyedShips} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {secondPlayerShips} ships left.");
            }

        }

        private static void ShipsOperations(string[][] battlefield, int row, int col, ref int firstPlayerShips, ref int secondPlayerShips, ref int destroyedShips)
        {
            if (battlefield[row][col] == "<")
            {
                DestroyShip(battlefield, row, col, ref firstPlayerShips, ref destroyedShips);
            }
            else if (battlefield[row][col] == ">")
            {
                DestroyShip(battlefield, row, col, ref secondPlayerShips, ref destroyedShips);
            }
        }

        private static void DestroyShip(string[][] battlefield, int row, int col, ref int countOfShips, ref int destroyedShips)
        {
            battlefield[row][col] = "X"; 
            countOfShips--;
            destroyedShips++;
        }

        private static void DetonateAdjacentFields(string[][] battlefield, ref int firstPlayerShips, ref int secondPlayerShips, int row, int col, ref int destroyedShips)
        {
            if (Validation(battlefield, row + 1, col))
            {
                row++;
                ShipsOperations(battlefield, row, col, ref firstPlayerShips, ref secondPlayerShips, ref destroyedShips);
                row--;
            }
            if (Validation(battlefield, row + 1, col + 1))
            {
                row++;
                col++;
                ShipsOperations(battlefield, row, col, ref firstPlayerShips, ref secondPlayerShips, ref destroyedShips);
                row--;
                col--;
            }
            if (Validation(battlefield, row, col + 1))
            {
                col++;
                ShipsOperations(battlefield, row, col, ref firstPlayerShips, ref secondPlayerShips, ref destroyedShips);
                col--;
            }
            if (Validation(battlefield, row - 1, col + 1))
            {
                row--;
                col++;
                ShipsOperations(battlefield, row, col, ref firstPlayerShips, ref secondPlayerShips, ref destroyedShips);
                row++;
                col--;
            }
            if (Validation(battlefield, row - 1, col))
            {
                row--;
                ShipsOperations(battlefield, row, col, ref firstPlayerShips, ref secondPlayerShips, ref destroyedShips);
                row++;
            }
            if (Validation(battlefield, row - 1, col - 1))
            {
                row--;
                col--;
                ShipsOperations(battlefield, row, col, ref firstPlayerShips, ref secondPlayerShips, ref destroyedShips);
                row++;
                col++;
            }
            if (Validation(battlefield, row, col - 1))
            {
                col--;
                ShipsOperations(battlefield, row, col, ref firstPlayerShips, ref secondPlayerShips, ref destroyedShips);
                col++;
            }
            if (Validation(battlefield, row + 1, col - 1))
            {
                row++;
                col--;
                ShipsOperations(battlefield, row, col, ref firstPlayerShips, ref secondPlayerShips, ref destroyedShips);
                row--;
                col++;
            }

        }

        public static bool Validation(string[][] battlefield, int rowIdx, int colIdx)
        {
            if (rowIdx >= 0 && rowIdx < battlefield.Length &&
                colIdx >= 0 && colIdx < battlefield[rowIdx].Length)
            {
                return true;
            }

            return false;
        }
        private static void FillMatrix(string[][] battlefield, ref int firstPlayerShips, ref int secondPlayerShips)
        {
            for (int row = 0; row < battlefield.Length; row++)
            {
                battlefield[row] = ReadStringArray();
                for (int col = 0; col < battlefield[row].Length; col++)
                {
                    if (battlefield[row][col] == "<")
                    {
                        firstPlayerShips++;
                    }
                    else if (battlefield[row][col] == ">")
                    {
                        secondPlayerShips++;
                    }
                }
            }
        }
        private static string[] ReadStringArray()
        {
            return Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
        }
    }
}
