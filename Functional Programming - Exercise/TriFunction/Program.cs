using System;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string, int, bool> filter = (string word, int num) =>
            {
                int sum = 0;
                foreach (var element in word)
                {
                    sum += (int)element;
                }

                return sum >= num;
            };

            foreach (var item in names)
            {
                if (filter(item, num))
                {
                    Console.WriteLine(item);
                    break;
                }
            }
        }
    }
}
