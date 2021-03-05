using System;
using System.Collections.Generic;
using System.Linq;

namespace _03ShoppingSpree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            string[] peopleInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] productsInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            try
            {
                foreach (var item in peopleInfo)
                {
                    string[] personInfo = item.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    Person currPerson = new Person(personInfo[0], decimal.Parse(personInfo[1]));
                    people.Add(currPerson);
                }
                foreach (var item in productsInfo)
                {
                    string[] productInfo = item.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    Product currProduct = new Product(productInfo[0], decimal.Parse(productInfo[1]));
                    products.Add(currProduct);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }


            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] data = input.Split(" ");
                string personName = data[0];
                string productName = data[1];

                Person person = people.First(p => p.Name == personName);
                Product product = products.First(p => p.Name == productName);

                person.Buy(product);
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
