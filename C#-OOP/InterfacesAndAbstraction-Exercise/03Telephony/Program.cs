using System;
using System.Collections.Generic;
using System.Linq;

namespace _03Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split().ToList();

            foreach (var number in numbers)
            {
                if (number.Length == 7)
                {
                    ICallable phone = new StationaryPhone();
                    phone.Call(number);
                }
                else
                {
                    ICallable phone = new Smartphone();
                    phone.Call(number);
                }
            }

            List<string> sites = Console.ReadLine().Split().ToList();

            foreach (var url  in sites)
            {
                IBrowseable phone = new Smartphone();
                phone.BrowseWWW(url);
            }
        }
    }
}
