using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> counter = new Dictionary<string, int>();
            string[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < nums.Length; i++)
            {
                string number = nums[i];
                if (counter.ContainsKey(number))
                {
                    counter[number]++;
                }
                else
                {
                    counter.Add(number, 1);
                }
            }
            foreach (var item in counter)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }

        }
    }
}
