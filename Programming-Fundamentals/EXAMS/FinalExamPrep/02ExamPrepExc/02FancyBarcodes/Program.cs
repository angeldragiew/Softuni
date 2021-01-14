using System;
using System.Text.RegularExpressions;

namespace _02FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@[#]+([A-Z][A-Za-z0-9]{4,}[A-Z]{1})@[#]+";
            string productGroupPattern = @"\d";

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();

                Match match = Regex.Match(barcode, pattern);

                if (match.Success)
                {
                    MatchCollection productGroup = Regex.Matches(barcode, productGroupPattern);

                    if (productGroup.Count>0)
                    {
                        Console.WriteLine($"Product group: {string.Join("",productGroup)}");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: 00");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }

        }
    }
}
