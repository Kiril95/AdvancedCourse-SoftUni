using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        public List<Employee> Data;
        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Data = new List<Employee>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.Data.Count;

        public void Add(Employee employee)
        {
            if (Capacity > Count)
            {
                this.Data.Add(employee);
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
        public Employee GetOldestEmployee()
        {
            if (Data.Count > 0)
            {
                var search = Data.Select(x => x.Age).Max();
                return Data.Find(x => x.Age == search);
            }

            return null;
        }
        public Employee GetEmployee(string name)
        {
            if (Data.Any(x => x.Name == name))
            {
                return Data.FirstOrDefault(x => x.Name == name);
            }

            return null;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {this.Name}:");

            foreach (var person in this.Data)
            {
                sb.AppendLine(person.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
