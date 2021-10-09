using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] forQueueing = ReadIntArray();
            int[] forStacking = ReadIntArray();

            Queue<int> ingredientsValues = new Queue<int>(forQueueing);
            Stack<int> freshnessValues = new Stack<int>(forStacking);
            Dictionary<string, int> menu = new Dictionary<string, int>
            {
                {"Chocolate cake", 0},
                {"Dipping sauce", 0},
                {"Green salad", 0},
                {"Lobster", 0}
            };
            string cake = "Chocolate cake";
            string sauce = "Dipping sauce";
            string salad = "Green salad";
            string lobster = "Lobster";

            while (ingredientsValues.Count > 0 && freshnessValues.Count > 0)
            {
                int currentIngredient = ingredientsValues.Peek();
                int currentFreshness = freshnessValues.Peek();
                bool success = false;

                if (currentIngredient <= 0)
                {
                    ingredientsValues.Dequeue();
                    continue;
                }

                int cooking = currentIngredient * currentFreshness;

                if (cooking.Equals(150))
                {
                    success = true;
                    menu[sauce]++;
                }
                else if (cooking.Equals(250))
                {
                    success = true;
                    menu[salad]++;
                }
                else if (cooking.Equals(300))
                {
                    success = true;
                    menu[cake]++;
                }
                else if (cooking.Equals(400))
                {
                    success = true;
                    menu[lobster]++;
                }
                else
                {
                    freshnessValues.Pop();
                    ingredientsValues.Enqueue(ingredientsValues.Dequeue() + 5);
                }

                if (success)
                {
                    ingredientsValues.Dequeue();
                    freshnessValues.Pop();
                }

            }

            menu = menu
                .Where(x => x.Value != 0)
                .ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine(menu.Keys.Count == 4
                ? "Applause! The judges are fascinated by your dishes!"
                : "You were voted off. Better luck next year.");

            if (ingredientsValues.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredientsValues.Sum()}");
            }

            PrintKeyValuePairs(menu);
        }

        private static void PrintKeyValuePairs(Dictionary<string, int> menu)
        {
            foreach (var meal in menu)
            {
                Console.WriteLine(string.Join(Environment.NewLine, $" # {meal.Key} --> {meal.Value}"));
            }
        }

        private static int[] ReadIntArray()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
