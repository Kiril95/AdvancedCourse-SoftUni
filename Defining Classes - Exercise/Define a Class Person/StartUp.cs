using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person human = new Person();

            human.Name = "Peter";
            human.Age = 20;

            human.Name = "George";
            human.Age = 18;

            human.Name = "Jose";
            human.Age = 43;

        }
    }
}
