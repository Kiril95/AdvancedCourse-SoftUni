using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        public List<Racer> Data;
        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Data = new List<Racer>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.Data.Count;

        public void Add(Racer racer)
        {
            if (Capacity > Count)
            {
                this.Data.Add(racer);
            }
        }
        public bool Remove(string name)
        {
            if (Data.Any(x => x.Name == name))
            {
                var target = Data.Find(x => x.Name == name);
                Data.Remove(target);

                return true;
            }
            return false;
        }
        public Racer GetOldestRacer()
        {
            if (Data.Count > 0)
            {
                var search = Data.Select(x => x.Age).Max();
                return Data.Find(x => x.Age == search);
            }

            return null;
        }
        public Racer GetRacer(string name)
        {
            if (Data.Any(x => x.Name == name))
            {
                return Data.FirstOrDefault(x => x.Name == name);
            }

            return null;
        }
        public Racer GetFastestRacer()
        {
            if (Data.Count > 0)
            {
                var fastest = Data.Select(x => x.Car.Speed).Max();
                return Data.FirstOrDefault(x => x.Car.Speed == fastest);
            }

            return null;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {this.Name}:");

            foreach (var person in this.Data)
            {
                sb.AppendLine(person.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
