using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family clan = new Family(new List<Person>());

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();

                string name = commands[0];
                int age = int.Parse(commands[1]);
                Person individual = new Person(name, age);
                clan.AddMember(individual);
            }

            IOrderedEnumerable<Person> persons = clan.Members
                .Where(x => x.Age > 30)
                .OrderBy(x => x.Name);

            foreach (Person human in persons)
            {
                Console.WriteLine($"{human.Name} - {human.Age}");
            }
        }
    }
}
