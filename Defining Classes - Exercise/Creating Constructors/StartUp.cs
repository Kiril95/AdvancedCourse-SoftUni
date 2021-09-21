using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person human = new Person();
            Person human2 = new Person(int.Parse(Console.ReadLine()));
            Person human3 = new Person(Console.ReadLine(), int.Parse(Console.ReadLine()));

        }
    }
}
