﻿using System;

namespace GenericBoxOfInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(number);
                Console.WriteLine(box);
            }

        }
    }
}
