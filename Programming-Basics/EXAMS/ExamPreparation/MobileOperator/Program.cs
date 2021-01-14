using System;

namespace MobileOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            string contract = Console.ReadLine(); 
            string contractType = Console.ReadLine(); 
            string mobileInternet = Console.ReadLine();
            int months = int.Parse(Console.ReadLine());

            double fee = 0;

            if (contract == "one")
            {
                switch (contractType)
                {
                    case "Small":
                        fee = 9.98;
                        break;
                    case "Middle":
                        fee = 18.99;
                        break;
                    case "Large":
                        fee = 25.98;
                        break;
                    case "ExtraLarge":
                        fee = 35.99;
                        break;
                }
            }
            else
            {
                switch (contractType)
                {
                    case "Small":
                        fee = 8.58;
                        break;
                    case "Middle":
                        fee = 17.09;
                        break;
                    case "Large":
                        fee = 23.59;
                        break;
                    case "ExtraLarge":
                        fee = 31.79;
                        break;
                }
            }

            if (mobileInternet == "yes")
            {
                if (fee <= 10)
                {
                    fee += 5.50;
                }else if (fee <= 30)
                {
                    fee += 4.35;
                }
                else
                {
                    fee += 3.85;
                }
            }

            if (contract == "two")
            {
                fee -= fee * (3.75 / 100);
            }

            double total = fee * months;

            Console.WriteLine($"{total:f2} lv.");
        }
    }
}
