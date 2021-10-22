using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;
        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Data = new List<Car>();
        }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public List<Car> Data { get; private set; }
        public int Count => this.Data.Count;

        public void Add(Car car)
        {
            if (Capacity > Count)
            {
                Data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            if (Data.Any(x => x.Manufacturer == manufacturer) && Data.Any(x => x.Model == model))
            {
                var targetCar = Data
                    .Where(x => x.Manufacturer == manufacturer)
                    .FirstOrDefault(x => x.Model == model);
                Data.Remove(targetCar);

                return true;
            }

            return false;
        }
        public Car GetLatestCar()
        {
            if (Data.Count > 0)
            {
                var search = Data.Select(x => x.Year).Max();
                var latestOne = Data.FirstOrDefault(x => x.Year == search);
                return latestOne;
            }

            return null;
        }
        public Car GetCar(string manufacturer, string model)
        {
            bool firstCheck = Data.Exists(x => x.Manufacturer == manufacturer);
            bool secondCheck = Data.Exists(x => x.Model == model);

            if (firstCheck && secondCheck)
            {
                var targetCar = Data
                    .Where(x => x.Manufacturer == manufacturer)
                    .FirstOrDefault(x => x.Model == model);
                return targetCar;
            }

            return null;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");

            foreach (var car in this.Data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}