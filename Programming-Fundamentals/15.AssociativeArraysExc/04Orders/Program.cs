using System;
using System.Collections.Generic;
using System.Linq;

namespace _04Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();
           

            string input;

            while ((input = Console.ReadLine()) != "buy")
            {
                string[] cmdArgs = input.Split().ToArray();

                string currProduct = cmdArgs[0];
                double price = double.Parse(cmdArgs[1]);
                int quantity = int.Parse(cmdArgs[2]);

                if (products.ContainsKey(currProduct))
                {
                    products[currProduct].Price = price;
                    products[currProduct].Quantity += quantity;
                }
                else
                {
                    products.Add(currProduct, new Product());
                    products[currProduct].Price = price;
                    products[currProduct].Quantity = quantity;
                }
            }

            foreach (var item in products)
            {
                double totalPrice = item.Value.Price*item.Value.Quantity;
                Console.WriteLine($"{item.Key} -> {totalPrice:f2}");
            }
        }

        class Product
        {
            public double Price { get; set; }
            public int Quantity { get; set; }
        }
    }
}
