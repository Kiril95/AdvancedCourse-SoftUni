using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] forQueueing = ReadIntArray();
            int[] forStacking = ReadIntArray();

            Queue<int> effects = new Queue<int>(forQueueing);
            Stack<int> casings = new Stack<int>(forStacking);
            Dictionary<string, int> bombPouch = new Dictionary<string, int>
            {
                {"Cherry Bombs", 0},
                {"Datura Bombs", 0},
                {"Smoke Decoy Bombs", 0}
            };
            string datura = "Datura Bombs";
            string cherry = "Cherry Bombs";
            string smoke = "Smoke Decoy Bombs";
            bool filledPouch = false;

            while (effects.Count > 0 && casings.Count > 0)
            {
                int currentEffect = effects.Peek();
                int currentCasing = casings.Peek();
                bool success = false;

                int tinker = currentEffect + currentCasing;

                if (tinker.Equals(40))
                {
                    success = true;
                    bombPouch[datura]++;
                }
                else if (tinker.Equals(60))
                {
                    success = true;
                    bombPouch[cherry]++;
                }
                else if (tinker.Equals(120))
                {
                    success = true;
                    bombPouch[smoke]++;
                }
                else
                {
                    casings.Push(casings.Pop() - 5);
                }

                if (success)
                {
                    effects.Dequeue();
                    casings.Pop();
                }

                if (bombPouch[datura] >= 3 && bombPouch[cherry] >= 3 && bombPouch[smoke] >= 3)
                {
                    filledPouch = true;
                    break;
                }

            }
            GC.Collect();
            Console.WriteLine(filledPouch
                ? "Bene! You have successfully filled the bomb pouch!"
                : "You don't have enough materials to fill the bomb pouch.");

            Console.WriteLine(effects.Any() 
                ? $"Bomb Effects: {string.Join(", ", effects)}" 
                : "Bomb Effects: empty");

            Console.WriteLine(casings.Any()
                ? $"Bomb Casings: {string.Join(", ", casings)}"
                : "Bomb Casings: empty");

            PrintKeyValuePairs(bombPouch);

        }
        private static void PrintKeyValuePairs(Dictionary<string, int> bombPouch)
        {
            foreach (var bomb in bombPouch)
            {
                Console.WriteLine(string.Join(Environment.NewLine, $"{bomb.Key}: {bomb.Value}"));
            }
        }
        private static int[] ReadIntArray()
        {
            return Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
