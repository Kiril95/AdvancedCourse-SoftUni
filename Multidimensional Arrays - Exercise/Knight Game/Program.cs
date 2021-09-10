using System;
using System.Data;
using System.Security.Cryptography;

namespace Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[][] jaggy = new char[size][];
            for (int row = 0; row < jaggy.Length; row++)
            {
                jaggy[row] = Console.ReadLine().ToCharArray();
            }
            int removed = 0;

            while (true)
            {
                int currRow = -1;
                int currCol = -1;
                int maxAttacked = 0;

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (jaggy[row][col] == 'K')
                        {
                            int tempAttacks = Counted(jaggy, row, col);

                            if (tempAttacks > maxAttacked)
                            {
                                maxAttacked = tempAttacks;
                                currRow = row;
                                currCol = col;

                            }
                        }
                    }
                }

                if (maxAttacked > 0)
                {
                    jaggy[currRow][currCol] = '0';
                    removed++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(removed);
        }
        public static int Counted(char[][] jaggy, int row, int col)
        {
            int attack = 0;
            if (Validation(jaggy.Length, row + 1, col - 2) &&
                jaggy[row + 1][col - 2] == 'K')
            {
                attack++;
            }

            if (Validation(jaggy.Length, row - 1, col - 2) &&
                jaggy[row - 1][col - 2] == 'K')
            {
                attack++;
            }

            if (Validation(jaggy.Length, row - 1, col + 2) &&
                jaggy[row - 1][col + 2] == 'K')
            {
                attack++;
            }

            if (Validation(jaggy.Length, row + 1, col + 2) &&
                jaggy[row + 1][col + 2] == 'K')
            {
                attack++;
            }

            if (Validation(jaggy.Length, row - 2, col - 1) &&
                jaggy[row - 2][col - 1] == 'K')
            {
                attack++;
            }

            if (Validation(jaggy.Length, row - 2, col + 1) &&
                jaggy[row - 2][col + 1] == 'K')
            {
                attack++;
            }

            if (Validation(jaggy.Length, row + 2, col - 1) &&
                jaggy[row + 2][col - 1] == 'K')
            {
                attack++;
            }

            if (Validation(jaggy.Length, row + 2, col + 1) &&
                jaggy[row + 2][col + 1] == 'K')
            {
                attack++;
            }

            return attack;
        }
        public static bool Validation(int size, int row, int col)
        {
            if (row >= 0 && row < size &&
                col >= 0 && col < size)
            {
                return true;
            }

            return false;
        }
        
    }
}
