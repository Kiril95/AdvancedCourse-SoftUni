using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        public List<Pet> Data;
        public Clinic(int capacity)
        {
            Data = new List<Pet>();
            Capacity = capacity;
        }
        public int Capacity { get; set; }
        public int Count => this.Data.Count;

        public void Add(Pet pet)
        {
            if (Capacity > Count)
            {
                this.Data.Add(pet);
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
        public Pet GetPet(string name, string owner)
        {
            bool firstCheck = Data.Exists(x => x.Name == name);
            bool secondCheck = Data.Exists(x => x.Owner == owner);

            if (firstCheck && secondCheck)
            {
                return Data.Where(x => x.Name == name)
                           .FirstOrDefault(x => x.Owner == owner);
            }

            return null;
        }
        public Pet GetOldestPet()
        {
            if (Data.Count > 0)
            {
                var oldest = Data.Select(x => x.Age).Max();
                return Data.FirstOrDefault(x => x.Age == oldest);
            }

            return null;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");

            foreach (var pet in this.Data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
