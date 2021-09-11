using System;
using System.Collections.Generic;

namespace Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int times = int.Parse(Console.ReadLine());
            Dictionary<int, int> result = new Dictionary<int, int>();

            for (int i = 0; i < times; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (result.ContainsKey(num))
                {
                    result[num]++;
                }
                else
                {
                    result.Add(num, 1);
                }
            }

            foreach (var item in result)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                    break;
                }
            }
        }
    }
}
