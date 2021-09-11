using System;
using System.Collections.Generic;
using System.Linq;

namespace Product_Shop
{
    class Shop
    {
        public string Product { get; set; }
        public double Price { get; set; }

        public Shop(string product, double price)
        {
            Product = product;
            Price = price;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Shop> market = new List<Shop>();
            Dictionary<string, List<Shop>> stores = new Dictionary<string, List<Shop>>();
            string command = Console.ReadLine();

            while (command != "Revision")
            {
                string[] operations = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = operations[0];
                string product = operations[1];
                double price = double.Parse(operations[2]);
                Shop storage = new Shop(product, price);

                if (stores.ContainsKey(shop))
                {
                    stores[shop].Add(storage);
                }
                else
                {
                    stores.Add(shop, new List<Shop>{ storage });
                }

                command = Console.ReadLine();
            }

            foreach (var item in stores.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}-> ");
                foreach (var list in item.Value)
                {
                    Console.WriteLine($"Product: {list.Product}, Price: {list.Price}");
                }
                
            }
            
        }
    }
}
