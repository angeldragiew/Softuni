using System;
using System.Text.RegularExpressions;

namespace _03SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\B%(?<name>[A-Z][a-z]+)%(?:\w*)<(?<product>[A-Za-z]+)>(?:\w*)\|(?<quantity>[\d]+)\|(?:\w*)(?<price>[\d]+[\.]?[\d]+)\$\B";

            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);

            while (input != "end of shift")
            {
                Match match = regex.Match(input);
                
                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string product = match.Groups["product"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    double quantity = double.Parse(match.Groups["quantity"].Value);

                    Console.WriteLine($"{name}: {product} - {price*quantity:f2}");
                }

                input = Console.ReadLine();
            }
        }
    }
}
