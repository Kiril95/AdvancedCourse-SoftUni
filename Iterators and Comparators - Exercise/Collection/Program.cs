using System;
using System.Linq;

namespace Collection
{
    public class Program
    {
        static void Main(string[] args)
        {
            ListyIterator<string> storage = new ListyIterator<string>();

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] operations = command.Split().ToArray();

                if (operations[0] == "Create")
                {
                    Create(ref storage, operations);
                }

                else if (operations[0] == "Move")
                {
                    Console.WriteLine(storage.Move());
                }

                else if (operations[0] == "HasNext")
                {
                    Console.WriteLine(storage.HasNext());
                }

                else if (operations[0] == "Print")
                {
                    Console.WriteLine(storage.Print());
                }

                else if(operations[0] == "PrintAll")
                {
                    storage.PrintAll();
                }

                command = Console.ReadLine();
            }

        }
        private static void Create(ref ListyIterator<string> storage, string[] operations)
        {
            if (operations.Length > 1)
            {
                storage = new ListyIterator<string>(operations.Skip(1).ToArray());
            }
            else
            {
                storage = new ListyIterator<string>();
            }
        }
    }
}
