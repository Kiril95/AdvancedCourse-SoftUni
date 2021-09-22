using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = info[0];
                int speed = int.Parse(info[1]);
                int power = int.Parse(info[2]);
                int weight = int.Parse(info[3]);
                string type = info[4];

                double tire1Pressure = double.Parse(info[5]);
                int tire1Age = int.Parse(info[6]);

                double tire2Pressure = double.Parse(info[7]);
                int tire2Age = int.Parse(info[8]);

                double tire3Pressure = double.Parse(info[9]);
                int tire3Age = int.Parse(info[10]);

                double tire4Pressure = double.Parse(info[11]);
                int tire4Age = int.Parse(info[12]);

                Engine engine = new Engine(speed, power);
                Cargo cargo = new Cargo(weight, type);
                List<Tire> tires = new List<Tire>
                {
                    new Tire(tire1Age, tire1Pressure),
                    new Tire(tire2Age, tire2Pressure),
                    new Tire(tire3Age, tire3Pressure),
                    new Tire(tire4Age, tire4Pressure),
                };

                Car list = new Car(model, engine, cargo, tires);
                cars.Add(list);
            }
            string command = Console.ReadLine();

            Console.WriteLine(string.Join(Environment.NewLine, cars.Where(Filter(command))));

        }
        public static Func<Car, bool> Filter(string type)
        {
            if (type == "fragile")
            {
                return x => x.Cargo.CargoType == type && x.Tire.Where(y => y.Pressure < 1).ToArray().Length != 0;
            }
            else
            {
                return x => x.Cargo.CargoType == type && x.Engine.EnginePower > 250;

            }
        }
    }
}
