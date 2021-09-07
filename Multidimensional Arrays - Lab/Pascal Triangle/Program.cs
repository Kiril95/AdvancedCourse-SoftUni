using System;

namespace Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long size = long.Parse(Console.ReadLine());

            long[][] jaggy = new long[size][];

            for (int i = 0; i < jaggy.Length; i++)
            {
                long[] arr = new long[i + 1];
                arr[0] = 1;
                arr[i] = 1;

                for (int j = 1; j < i; j++)
                {
                    arr[j] = jaggy[i - 1][j] + jaggy[i - 1][j - 1];
                }

                jaggy[i] = arr;
            }

            foreach (var item in jaggy)
            {
                Console.WriteLine(string.Join(' ', item));
            }

        }
    }
}
