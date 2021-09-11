using System;
using System.Collections.Generic;
using System.Linq;

namespace Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> licencePlates = new HashSet<string>();
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] operations = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string direction = operations[0];
                string plate = operations[1];

                if (direction == "IN")
                {
                    licencePlates.Add(plate);
                }
                else if (direction == "OUT")
                {
                    licencePlates.Remove(plate);
                }
                command = Console.ReadLine();
            }

            if (licencePlates.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, licencePlates));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }

        }
    }
}
