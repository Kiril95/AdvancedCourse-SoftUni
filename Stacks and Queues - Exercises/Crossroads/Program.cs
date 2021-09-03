using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int durationLight = int.Parse(Console.ReadLine());
            int windowPassage = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int passed = 0;
            string temp = string.Empty;
            string command = Console.ReadLine();

            while (command != "END")
            {
                if (command == "green")
                {
                    int greenLight = durationLight;
                    int window = windowPassage;
                    while (cars.Count > 0 && greenLight > 0)
                    {
                        string car = cars.Dequeue();
                        greenLight -= car.Length;

                        if (greenLight > 0)
                        {
                            passed++;
                        }
                        else
                        {
                            window += greenLight;
                            if (window < 0)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{car} was hit at {car[car.Length + window]}.");
                                return;
                            }
                            else
                            {
                                passed++;
                            }
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);

                }
                command = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passed} total cars passed the crossroads.");

        }
    }
}
