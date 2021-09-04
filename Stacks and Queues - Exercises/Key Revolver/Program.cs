using System;
using System.Collections.Generic;
using System.Linq;

namespace Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPr = int.Parse(Console.ReadLine());
            int gunBarrel = int.Parse(Console.ReadLine());
            int[] array1 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] array2 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int secretPr = int.Parse(Console.ReadLine());
            int ammo = 0;
            int money = 0;
            Stack<int> bullets = new Stack<int>(array1);
            Queue<int> locks = new Queue<int>(array2);

            while (bullets.Any() && locks.Any())
            {

                if (bullets.Peek() <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                    bullets.Pop();
                    secretPr -= bulletPr;
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bullets.Pop();
                    secretPr -= bulletPr;
                }

                ammo++;
                if (bullets.Any() && gunBarrel == ammo)
                {
                    Console.WriteLine("Reloading!");
                    ammo = 0;
                }
                money++;
            }

            GC.Collect();
            if (!locks.Any())
            {
                Console.WriteLine($"{bullets.Count()} bullets left. Earned ${secretPr}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count()}");
            }
        }
    }
}
