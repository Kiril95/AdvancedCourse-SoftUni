using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text.RegularExpressions;

namespace SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> peasantGuests = new HashSet<string>();
            string guest = Console.ReadLine();

            while (guest != "PARTY")
            {
                Match matched = Regex.Match(guest, @"[\w]{8}");
                bool vipCheck = Regex.IsMatch(guest, @"^\d");

                if (matched.Success && vipCheck)
                {
                    vipGuests.Add(guest);
                }
                else
                {
                    peasantGuests.Add(guest);
                }

                guest = Console.ReadLine();
            }

            string actualGuest = Console.ReadLine();

            while (actualGuest != "END")
            {
                if (vipGuests.Contains(actualGuest))
                {
                    vipGuests.Remove(actualGuest);
                }
                else if (peasantGuests.Contains(actualGuest))
                {
                    peasantGuests.Remove(actualGuest);
                }

                actualGuest = Console.ReadLine();
            }

            Console.WriteLine(vipGuests.Count + peasantGuests.Count);

            if (vipGuests.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, vipGuests));
            }
            if (peasantGuests.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, peasantGuests));
            }
            
        }
    }
}
