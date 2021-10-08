using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public List<Car> Participants;
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new List<Car>();
        }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }


        public int Count => this.Participants.Count();
        public void Add(Car car)
        {
            bool check = Participants.Exists(x => x.LicensePlate == car.LicensePlate);

            if (Capacity > Count && car.HorsePower <= MaxHorsePower && !check)
            {
                Participants.Add(car);
            }

        }

        public bool Remove(string plate)
        {
            if (Participants.Any(x => x.LicensePlate == plate))
            {
                var temp = Participants.FirstOrDefault(x => x.LicensePlate == plate);
                Participants.Remove(temp);
                return true;
            }

            return false;
        }

        public Car FindParticipant(string plate)
        {
            var exists = Participants.Any(x => x.LicensePlate == plate);

            if (exists)
            {
                return Participants.FirstOrDefault(x => x.LicensePlate == plate);
            }

            return null;
        }

        public Car GetMostPowerfulCar()
        {
            if (Participants.Count > 0)
            {
                var mostHP = Participants.Select(x => x.HorsePower).Max();
                var topCar = Participants.FirstOrDefault(x => x.HorsePower == mostHP);
                return topCar;
            }

            return null;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");

            foreach (var car in this.Participants)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
