using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] forQueueing = ReadIntArray();
            int[] forStacking = ReadIntArray();
            Queue<int> liquids = new Queue<int>(forQueueing);
            Stack<int> ingredients = new Stack<int>(forStacking);
            SortedDictionary<string, int> menu = new SortedDictionary<string, int>
            {
                {"Bread", 0},
                {"Cake", 0},
                {"Fruit Pie", 0},
                {"Pastry", 0}
            };
            string bread = "Bread";
            string cake = "Cake";
            string pie = "Fruit Pie";
            string pastry = "Pastry";
            
            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int currentLiquid = liquids.Peek();
                int currentIngredient = ingredients.Peek();
                bool success = false;

                int cooking = currentLiquid + currentIngredient;

                if (cooking.Equals(25))
                {
                    success = true;
                    menu[bread]++;
                }
                else if (cooking.Equals(50))
                {
                    success = true;
                    menu[cake]++;
                }
                else if (cooking.Equals(75))
                {
                    success = true;
                    menu[pastry]++;
                }
                else if (cooking.Equals(100))
                {
                    success = true;
                    menu[pie]++;
                }
                else
                {
                    liquids.Dequeue();
                    int increasedValue = ingredients.Pop() + 3;
                    ingredients.Push(increasedValue);
                    
                }

                if (success)
                {
                    liquids.Dequeue();
                    ingredients.Pop();
                }
            }
            var tempMenu = menu
                .Where(x => x.Value != 0)
                .ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine(tempMenu.Keys.Count == 4
                ? "Wohoo! You succeeded in cooking all the food!"
                : "Ugh, what a pity! You didn't have enough materials to cook everything.");

            Console.WriteLine(liquids.Any() 
                ? $"Liquids left: {string.Join(", ", liquids)}" 
                : "Liquids left: none");

            Console.WriteLine(ingredients.Any()
                ? $"Ingredients left: {string.Join(", ", ingredients)}"
                : "Ingredients left: none");

            PrintKeyValuePairs(menu);
        }
        private static void PrintKeyValuePairs(SortedDictionary<string, int> menu)
        {
            foreach (var meal in menu)
            {
                Console.WriteLine(string.Join(Environment.NewLine, $"{meal.Key}: {meal.Value}"));
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
