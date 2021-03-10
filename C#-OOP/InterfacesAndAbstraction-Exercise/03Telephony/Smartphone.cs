using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03Telephony
{
    public class Smartphone : Phone, IBrowseable
    {
        public void BrowseWWW(string url)
        {
            if (url.Any(char.IsDigit))
            {
                Console.WriteLine("Invalid URL!");
            }
            else
            {
                Console.WriteLine($"Browsing: {url}!");
            }
        }

        public override void Call(string number)
        {
            if (number.All(char.IsDigit) == false)
            {
                Console.WriteLine("Invalid number!");
            }
            else
            {
                Console.WriteLine($"Calling... {number}");
            }
        }
    }
}
