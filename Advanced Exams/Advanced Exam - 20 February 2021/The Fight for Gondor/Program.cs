using System;
using System.Collections.Generic;
using System.Linq;

namespace The_Fight_for_Gondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());
            int[] forQueueing = ReadIntArray();
            Queue<int> defenses = new Queue<int>(forQueueing);
            Stack<int> orcs = new Stack<int>();

            for (int i = 1; i <= waves; i++)
            {
                if (defenses.Count <= 0)
                {
                    break;
                }
                int[] forStacking = ReadIntArray();

                if (i % 3 == 0)
                {
                    int bonus = int.Parse(Console.ReadLine());
                    defenses.Enqueue(bonus);
                }
                orcs = new Stack<int>(forStacking);

                while (orcs.Count > 0 && defenses.Count > 0)
                {
                    int currentOrc = orcs.Peek();
                    int currentPlate = defenses.Peek();

                    if (currentOrc > currentPlate)
                    {
                        int orc = orcs.Pop() - defenses.Dequeue();
                        orcs.Push(orc);
                    }
                    else if (currentPlate > currentOrc)
                    {
                        Queue<int> tempQueue = new Queue<int>();
                        int damagedPlate = defenses.Dequeue() - orcs.Pop();
                        tempQueue.Enqueue(damagedPlate);

                        for (int j = 0; j < defenses.Count; j++)
                        {
                            tempQueue.Enqueue(defenses.ElementAt(j));
                        }

                        defenses = tempQueue;
                    }
                    else if (currentOrc.Equals(currentPlate))
                    {
                        defenses.Dequeue();
                        orcs.Pop();
                    }
                }
            }
            GC.Collect();
            Console.WriteLine(defenses.Count > 0
                     ? "The people successfully repulsed the orc's attack."
                     : "The orcs successfully destroyed the Gondor's defense.");

            Console.WriteLine(defenses.Count > 0
                     ? $"Plates left: {string.Join(", ", defenses)}"
                     : $"Orcs left: {string.Join(", ", orcs)}");

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
