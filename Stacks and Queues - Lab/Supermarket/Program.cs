using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            Queue<string> queue = new Queue<string>();
            int counter = 0;

            while (name != "End")
            {
                if (name == "Paid")
                {
                    while (queue.Count > 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                    counter = 0;
                }
                else
                {
                    queue.Enqueue(name);
                    counter++;
                }
                name = Console.ReadLine();

            }
            Console.WriteLine($"{counter} people remaining.");
        }
    }
}
