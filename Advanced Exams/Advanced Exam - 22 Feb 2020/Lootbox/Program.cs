using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] forQueueing = ReadIntArray();
            int[] forStacking = ReadIntArray();

            Queue<int> firstBox = new Queue<int>(forQueueing);
            Stack<int> secondBox = new Stack<int>(forStacking);
            List<int> items = new List<int>();

            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int firstItem = firstBox.Peek();
                int secondItem = secondBox.Peek();
                int sum = firstItem + secondItem;

                if (sum % 2 == 0)
                {
                    items.Add(sum);
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    int targetItem = secondBox.Pop();
                    firstBox.Enqueue(targetItem);
                }
            }

            Console.WriteLine(!firstBox.Any() ? "First lootbox is empty" : "Second lootbox is empty");

            Console.WriteLine(items.Sum() >= 100
                ? $"Your loot was epic! Value: {items.Sum()}"
                : $"Your loot was poor... Value: {items.Sum()}");
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
