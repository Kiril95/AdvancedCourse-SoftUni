using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<string> words = new EqualityScale<string>("Boiko", "Boiko");
            Console.WriteLine(words.AreEqual());

            EqualityScale<int> numbers = new EqualityScale<int>(66, 69);
            Console.WriteLine(numbers.AreEqual());

        }
    }
}
