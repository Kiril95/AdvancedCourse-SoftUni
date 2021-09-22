using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                double fuelAmount = double.Parse(tokens[1]);
                double fuelPerOneKm = double.Parse(tokens[2]);
                Car info = new Car(model, fuelAmount, fuelPerOneKm);
                cars.Add(info);
            }
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[1];
                double amountOfKm = int.Parse(tokens[2]);

                cars.FirstOrDefault(x => x.Model == model).Drive(amountOfKm);

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));

        }
    }
}
