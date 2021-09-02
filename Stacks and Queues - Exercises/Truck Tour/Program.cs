using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumps = int.Parse(Console.ReadLine());
            //Queue<int> petrol = new Queue<int>();
            //Queue<int> distance = new Queue<int>();

            double current = 0;
            double result = 0;
            for (long i = 0; i < pumps; i++)
            {
                int[] array = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int amount = array[0];
                int distance = array[1];

                current += amount;

                if (current >= distance)
                {
                    current -= distance;
                }
                else
                {
                    result = i + 1;
                    current = 0;
                }

            }

            //GC.Collect();
            Console.WriteLine(result);
            
        }
    }
}
