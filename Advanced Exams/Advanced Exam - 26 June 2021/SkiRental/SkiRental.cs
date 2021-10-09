using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        public List<Ski> Data;
        public SkiRental(string name, int capacity)
        {
            this.Data = new List<Ski>();
            Name = name;
            Capacity = capacity;
        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => this.Data.Count();
        public void Add(Ski ski)
        {
            if (Capacity > Count)
            {
                this.Data.Add(ski);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            if (Data.Any(x => x.Manufacturer == manufacturer) && Data.Any(x => x.Model == model))
            {
                var targetSki = Data
                    .Where(x => x.Manufacturer == manufacturer)
                    .FirstOrDefault(x => x.Model == model);
                Data.Remove(targetSki);
                return true;
            }

            return false;
        }
        public Ski GetNewestSki()
        {
            if (Data.Count > 0)
            {
                var search = Data.Select(x => x.Year).Max();
                var newestOne = Data.FirstOrDefault(x => x.Year == search);
                return newestOne;
            }

            return null;
        }
        public Ski GetSki(string manufacturer, string model)
        {
            bool firstCheck = Data.Exists(x => x.Manufacturer == manufacturer);
            bool secondCheck = Data.Exists(x => x.Model == model);
            
            if (firstCheck && secondCheck)
            {
                var targetSki = Data
                    .Where(x => x.Manufacturer == manufacturer)
                    .FirstOrDefault(x => x.Model == model);
                return targetSki;
            }

            return null;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {this.Name}:");

            foreach (var ski in this.Data)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
