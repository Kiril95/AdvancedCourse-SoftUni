using System;
using System.Linq;

namespace The_Heigan_Dance
{
    public class Program
    {
        public static void Main()
        {
            // 70/100 ... Sorry, dear spectator. 
            double heiganHp = 3000000d;
            int playerHp = 18500;
            int playerRow = 7;
            int playerCol = 7;

            double playerDamage = double.Parse(Console.ReadLine());
            string spell = string.Empty;

            while (true)
            {
                if (playerHp >= 0)
                {
                    heiganHp -= playerDamage;
                }
                if (spell.Equals("Cloud"))
                {
                    playerHp -= 3500;
                }
                if (heiganHp <= 0 || playerHp <= 0)
                {
                    break;
                }

                string[] operations = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                spell = operations[0];
                var hitRow = int.Parse(operations[1]);
                var hitCol = int.Parse(operations[2]);

                if (InDamageRadius(hitRow, hitCol, playerRow, playerCol))
                {
                    if (!InDamageRadius(hitRow, hitCol, playerRow - 1, playerCol) && !WallReached(playerRow - 1))
                    {
                        playerRow--;
                        spell = "";
                    }
                    else if (!InDamageRadius(hitRow, hitCol, playerRow, playerCol + 1) && !WallReached(playerCol + 1))
                    {
                        playerCol++;
                        spell = "";
                    }
                    else if (!InDamageRadius(hitRow, hitCol, playerRow + 1, playerCol) && !WallReached(playerRow + 1))
                    {
                        playerRow++;
                        spell = "";
                    }
                    else if (!InDamageRadius(hitRow, hitCol, playerRow, playerCol - 1) && !WallReached(playerCol - 1))
                    {
                        playerCol--;
                        spell = "";
                    }
                    else
                    {
                        if (spell.Equals("Cloud"))
                        {
                            playerHp -= 3500;
                            spell = "Cloud";
                        }
                        else if (spell.Equals("Eruption"))
                        {
                            playerHp -= 6000;
                            spell = "Eruption";
                        }
                    }
                }

            }
            if (IsGameOver(playerRow, playerCol, playerHp ,playerDamage, heiganHp, spell))
            {
            }

        }
        private static bool IsGameOver(int playerRow, int playerCol, int playerHp, double playerDamage, double heiganHp, string spell)
        {
            if (playerHp <= 0 || heiganHp <= 0)
            {
                if (spell == "Cloud")
                {
                    spell = "Plague Cloud";
                }

                Console.WriteLine(heiganHp > 0
                    ? $"Heigan: {heiganHp:f2}"
                    : $"Heigan: Defeated!");

                Console.WriteLine(playerHp > 0
                    ? $"Player: {playerHp}"
                    : $"Player: Killed by {spell}");

                Console.WriteLine($"Final position: {playerRow}, {playerCol}");

                return true;
            }

            return false;
        }
        private static bool WallReached(int movePlayer)
        {
            return movePlayer < 0 || movePlayer >= 15;
        }

        private static bool InDamageRadius(int hitRow, int hitCol, int moveRow, int moveCol)
        {
            return ((hitRow - 1 <= moveRow && moveRow <= hitRow + 1)
                    && (hitCol - 1 <= moveCol && moveCol <= hitCol + 1));
        }
    }
}
