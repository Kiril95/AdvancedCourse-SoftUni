using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] forStacking = ReadIntArray();
            int[] forQueueing = ReadIntArray();
            int endTask = int.Parse(Console.ReadLine());

            Queue<int> threads = new Queue<int>(forQueueing);
            Stack<int> tasks = new Stack<int>(forStacking);

            while (tasks.Count > 0 && threads.Count > 0)
            {
                int currentThread = threads.Peek();
                int currentTask = tasks.Peek();

                if (currentTask == endTask)
                {
                    Console.WriteLine($"Thread with value {currentThread} killed task {currentTask}");
                    break;
                }
                if (currentThread >= currentTask)
                {
                    threads.Dequeue();
                    tasks.Pop();
                }
                else
                {
                    threads.Dequeue();
                }

            }
            Console.WriteLine(string.Join(" ", threads));
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
