using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?:\>\>)(?<furniture>(?:[A-Z]+)(?:[a-z]+)?)(?:<<)(?<price>(\d+).?(\d+?))(?:\!)(?<quantity>\d+)\b";

            var regex = new Regex(pattern);

            List<string> boughtFurnitures = new List<string>();
            double totalMoney = 0;
            string input;

            while ((input = Console.ReadLine())!= "Purchase")
            {
                if (regex.IsMatch(input))
                {
                    Match match = regex.Match(input);

                    string currFurniture = match.Groups["furniture"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);

                    boughtFurnitures.Add(currFurniture);
                    totalMoney += price * quantity;
                }
            }
            Console.WriteLine("Bought furniture:");
            foreach (var fur in boughtFurnitures)
            {
                Console.WriteLine(fur);
            }
            Console.WriteLine($"Total money spend: {totalMoney:f2}");
        }
    }
}
