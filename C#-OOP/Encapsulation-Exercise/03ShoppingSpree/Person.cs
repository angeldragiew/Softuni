using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            bagOfProducts = new List<Product>();
            Name = name;
            Money = money;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public void Buy(Product product)
        {
            if (this.Money < product.Cost)
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
            else
            {
                Money -= product.Cost;
                bagOfProducts.Add(product);
                Console.WriteLine($"{Name} bought {product.Name}");
            }
        }

        public override string ToString()
        {
            if (bagOfProducts.Count == 0)
            {
                return $"{Name} - Nothing bought";
            }
            return $"{Name} - {string.Join(", ", bagOfProducts.Select(p => p.Name))}";
        }
    }
}
