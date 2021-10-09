using System;
using System.Linq;

namespace Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[][] beach = new string[size][];
            FillMatrix(beach);

            int enemyTokens = 0;
            int playerTokens = 0;
            string command = Console.ReadLine();

            while (command != "Gong")
            {
                string[] operations = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string move = operations[0];
                int row = int.Parse(operations[1]);
                int col = int.Parse(operations[2]);

                if (move == "Find" && Validation(beach, row, col))
                {
                    CollectToken(beach, row, col, ref playerTokens);
                }

                else if (move == "Opponent" && Validation(beach, row, col))
                {
                    string direction = operations[3];

                    CollectToken(beach, row, col, ref enemyTokens);
                    EnemyMoves(beach, direction, row, col, ref enemyTokens);
                    
                }
                command = Console.ReadLine();
            }
            PrintMatrix(beach);
            Console.WriteLine($"Collected tokens: {playerTokens}");
            Console.WriteLine($"Opponent's tokens: {enemyTokens}");

        }
        private static void EnemyMoves(string[][] beach, string direction, int row, int col, ref int enemyTokens)
        {
            for (int i = 0; i < 3; i++)
            {
                if (direction == "up" && Validation(beach, row - 1, col))
                {
                    CollectToken(beach, row - 1, col, ref enemyTokens);
                    beach[row][col] = "-";
                    row--;
                }

                else if (direction == "down" && Validation(beach, row + 1, col))
                {
                    CollectToken(beach, row + 1, col, ref enemyTokens);
                    beach[row][col] = "-";
                    row++;
                }

                else if (direction == "left" && Validation(beach, row, col - 1))
                {
                    CollectToken(beach, row, col - 1, ref enemyTokens);
                    beach[row][col] = "-";
                    col--;
                }

                else if (direction == "right" && Validation(beach, row, col + 1))
                {
                    CollectToken(beach, row, col + 1, ref enemyTokens);
                    beach[row][col] = "-";
                    col++;
                }
            }
        }
        private static void CollectToken(string[][] beach, int row, int col, ref int tokens)
        {
            if (beach[row][col] == "T")
            {
                tokens++;
                beach[row][col] = "-";
            }
        }
        public static bool Validation(string[][] beach, int rowIdx, int colIdx)
        {
            if (rowIdx >= 0 && rowIdx < beach.Length &&
                colIdx >= 0 && colIdx < beach[rowIdx].Length)
            {
                return true;
            }

            return false;
        }
        private static void FillMatrix(string[][] beach)
        {
            for (int row = 0; row < beach.Length; row++)
            {
                beach[row] = ReadStringArray();
            }
        }
        private static void PrintMatrix(string[][] beach)
        {
            foreach (var row in beach)
            {
                Console.WriteLine(string.Join(" ", row));
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
