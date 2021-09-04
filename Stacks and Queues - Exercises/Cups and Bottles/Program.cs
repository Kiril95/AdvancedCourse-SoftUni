using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;

namespace Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] array2 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> cups = new Queue<int>(array1);
            Stack<int> bottles = new Stack<int>(array2);
            //Stack<int> wastedWaterStack = new Stack<int>(array2);
            int wasted = 0;

            while (bottles.Any() && cups.Any())
            {
                int currentBottle = bottles.Peek();
                int currentCup = cups.Peek();

                if (currentBottle >= currentCup)
                {
                    wasted += currentBottle - currentCup;
                    int temp = currentBottle - currentCup;
                    bottles.Pop();
                    cups.Dequeue();

                }

                else if (currentCup > currentBottle)
                {
                    int temp = currentCup - currentBottle;
                    bottles.Pop();

                    while (temp > 0 && bottles.Count != 0)
                    {
                       
                        int next = bottles.Peek();

                        if (next > temp)
                        {
                            wasted += next - temp;
                            temp -= next;
                        }
                        else
                        {
                            temp -= next;
                        }

                        bottles.Pop();
                    }

                    cups.Dequeue();
                }

            }
            if (bottles.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
                Console.WriteLine($"Wasted litters of water: {wasted}");
            }

            else if (cups.Any())
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                Console.WriteLine($"Wasted litters of water: {wasted}");
            }
        }
    }
}
