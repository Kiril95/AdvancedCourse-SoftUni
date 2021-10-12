using System;
using System.Linq;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[][] bakery = new char[size][];
            int startRow = -1;
            int startCol = -1;
            int cash = 0;
            bool targetMoney = false;
            FillMatrix(bakery, size, ref startRow, ref startCol);

            while (cash < 50 && targetMoney == false)
            {
                string direction = Console.ReadLine();
                bakery[startRow][startCol] = '-';

                if (Validation(bakery, startRow - 1, startCol) && direction == "up")
                {
                    startRow--;
                    Teleport(bakery, ref startRow, ref startCol);
                    GrabTheCash(bakery, startRow, startCol, ref cash);
                }

                else if (Validation(bakery, startRow + 1, startCol) && direction == "down")
                {
                    startRow++;
                    Teleport(bakery, ref startRow, ref startCol);
                    GrabTheCash(bakery, startRow, startCol, ref cash);
                }

                else if (Validation(bakery, startRow, startCol - 1) && direction == "left")
                {
                    startCol--;
                    Teleport(bakery, ref startRow, ref startCol);
                    GrabTheCash(bakery, startRow, startCol, ref cash);
                }

                else if (Validation(bakery, startRow, startCol + 1) && direction == "right")
                {
                    startCol++;
                    Teleport(bakery, ref startRow, ref startCol);
                    GrabTheCash(bakery, startRow, startCol, ref cash);
                }
                else
                {
                    bakery[startRow][startCol] = '-';
                    break;
                }

                if (cash >= 50)
                {
                    bakery[startRow][startCol] = 'S';
                    targetMoney = true;
                    break;
                }
            }
            Console.WriteLine(targetMoney == true
                ? "Good news! You succeeded in collecting enough money!"
                : "Bad news, you are out of the bakery.");
            Console.WriteLine($"Money: {cash}");

            PrintMatrix(bakery);
        }

        private static void Teleport(char[][] bakery, ref int startRow, ref int startCol)
        {
            if (bakery[startRow][startCol] == 'O')
            {
                bakery[startRow][startCol] = '-';
                for (int row = 0; row < bakery.Length; row++)
                {
                    for (int col = 0; col < bakery[row].Length; col++)
                    {
                        if (bakery[row][col] == 'O')
                        {
                            startRow = row;
                            startCol = col;
                            break;
                        }
                    }
                }
            }
        }
        private static void GrabTheCash(char[][] bakery, int startRow, int startCol, ref int cash)
        {
            if (bakery[startRow][startCol] != 'O' && bakery[startRow][startCol] != '-')
            {
                int sum = int.Parse(bakery[startRow][startCol].ToString());
                cash += sum;
                bakery[startRow][startCol] = '-';
            }
        }
        public static bool Validation(char[][] bakery, int rowIdx, int colIdx)
        {
            if (rowIdx >= 0 && rowIdx < bakery.Length &&
                colIdx >= 0 && colIdx < bakery[rowIdx].Length)
            {
                return true;
            }

            return false;
        }
        private static void FillMatrix(char[][] bakery, int size, ref int startRow, ref int startCol)
        {
            for (int row = 0; row < bakery.Length; row++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                bakery[row] = line;
                for (int col = 0; col < bakery[row].Length; col++)
                {
                    if (bakery[row][col] == 'S')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
        }
        private static void PrintMatrix(char[][] bakery)
        {
            foreach (var row in bakery)
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
