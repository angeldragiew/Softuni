using System;
using System.Text.RegularExpressions;

namespace _03SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\B%(?<name>[A-Z][a-z]+)%(?:[A-Za-z]*)<(?<product>[A-Za-z]+)>(?:[A-Za-z]*)\|(?<quantity>[\d]+)\|(?:[A-Za-z]*)(?<price>[\d]+[\.]?[\d]+)\$\B";

            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);
            double total = 0;
            while (input != "end of shift")
            {
                Match match = regex.Match(input);

                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string product = match.Groups["product"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    double quantity = double.Parse(match.Groups["quantity"].Value);
                    total += price * quantity;
                    Console.WriteLine($"{name}: {product} - {(price * quantity):f2}");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {total:f2}");
        }
    }
}
