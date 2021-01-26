using System;
using System.Collections.Generic;
using System.Linq;

namespace _03ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] info = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shop = info[0];
                string product = info[1];
                double price = double.Parse(info[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }

                if (!shops[shop].ContainsKey(product))
                {
                    shops[shop].Add(product, price);
                }
            }

            foreach (var shop in shops.OrderBy(n => n.Key).ToDictionary(k => k.Key, v => v.Value))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
