using System;
using System.Collections.Generic;
using System.Linq;

namespace Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] forStacking = ReadIntArray();
            int[] forQueueing = ReadIntArray();

            Queue<int> lillies = new Queue<int>(forQueueing);
            Stack<int> roses = new Stack<int>(forStacking);
            int storedFlowers = 0;
            int wreathsCount = 0;

            while (lillies.Count > 0 && roses.Count > 0)
            {
                int currentLilly = lillies.Peek();
                int currentRose = roses.Peek();
                int sum = currentLilly + currentRose;

                if (sum == 15)
                {
                    wreathsCount++;
                    lillies.Dequeue();
                    roses.Pop();
                }
                else if (sum < 15)
                {
                    storedFlowers += sum;
                    lillies.Dequeue();
                    roses.Pop();
                }
                else
                {
                    while (sum > 15)
                    {
                        sum -= 2;
                        if (sum == 15)
                        {
                            wreathsCount++;
                            lillies.Dequeue();
                            roses.Pop();
                        }
                        else if(sum < 15)
                        {
                            storedFlowers += sum;
                            lillies.Dequeue();
                            roses.Pop();
                        }
                    }
                }
            }
            while (storedFlowers > 15)
            {
                storedFlowers -= 15;
                wreathsCount++;
            }

            Console.WriteLine(wreathsCount >= 5
                ? $"You made it, you are going to the competition with {wreathsCount} wreaths!"
                : $"You didn't make it, you need {5 - wreathsCount} wreaths more!");
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
