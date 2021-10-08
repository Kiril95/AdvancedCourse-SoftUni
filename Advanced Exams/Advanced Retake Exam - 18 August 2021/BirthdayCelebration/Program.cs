using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] forQueueing = ReadIntArray();
            int[] forStacking = ReadIntArray();

            Queue<int> guests = new Queue<int>(forQueueing);
            Stack<int> plates = new Stack<int>(forStacking);
            int wastedFood = 0;

            while (plates.Count > 0 && guests.Count > 0)
            {
                int currentGuest = guests.Peek();
                int currentPlate = plates.Peek();

                if (currentPlate >= currentGuest)
                {
                    wastedFood += currentPlate - currentGuest;
                    plates.Pop();
                    guests.Dequeue();
                }

                else if (currentGuest > currentPlate)
                {
                    int temp = currentGuest - currentPlate;
                    plates.Pop();

                    while (temp > 0 && plates.Count != 0)
                    {
                        int next = plates.Peek();

                        if (next > temp)
                        {
                            wastedFood += next - temp;
                            temp -= next;
                        }
                        else
                        {
                            temp -= next;
                        }

                        plates.Pop();
                    }

                    guests.Dequeue();
                }

            }
            if (plates.Any())
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
                Console.WriteLine($"Wasted grams of food: {wastedFood}");
            }

            else if (guests.Any())
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
                Console.WriteLine($"Wasted grams of food: {wastedFood}");
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
