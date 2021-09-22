using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int times = int.Parse(Console.ReadLine());

            for (int i = 0; i < times; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = info[0];
                string power = info[1];

                if (info.Length == 2)
                {
                    engines.Add(new Engine(model, power));
                }
                else if (info.Length == 3)
                {

                    if (char.IsDigit(info[2][0]))
                    {
                        engines.Add(new Engine(model, power, info[2]));
                    }
                    else
                    {
                        engines.Add(new Engine(model, power, "n/a", info[2]));
                    }

                }
                else if (info.Length == 4)
                {
                    engines.Add(new Engine(model, power, info[2], info[3]));
                }
            }

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = info[0];
                Engine engine = engines.FirstOrDefault(x => x.Model == info[1]);

                if (info.Length == 2)
                {
                    cars.Add(new Car(model, engine));
                }
                else if (info.Length == 3)
                {

                    if (char.IsDigit(info[2][0]))
                    {
                        cars.Add(new Car(model, engine, info[2]));
                    }
                    else
                    {
                        cars.Add(new Car(model, engine, "n/a", info[2]));
                    }

                }
                else if (info.Length == 4)
                {
                    cars.Add(new Car(model, engine, info[2], info[3]));
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));

        }
    }
}
