using System;

namespace SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double number = double.Parse(Console.ReadLine());
            double price = 0;
            switch (product)
            {
                case "coffee":
                    if(city == "Sofia")
                    {
                        price = number*0.5;
                    }else if(city == "Plovdiv")
                    {
                        price = number * 0.4;
                    }
                    else if (city == "Varna")
                    {
                        price = number * 0.45;
                    }
                    break;
                case "water":
                    if (city == "Sofia")
                    {
                        price = number * 0.8;
                    }
                    else if (city == "Plovdiv")
                    {
                        price = number * 0.7;
                    }
                    else if (city == "Varna")
                    {
                        price = number * 0.7;
                    }
                    break;
                case "beer":
                    if (city == "Sofia")
                    {
                        price = number * 1.2;
                    }
                    else if (city == "Plovdiv")
                    {
                        price = number * 1.15;
                    }
                    else if (city == "Varna")
                    {
                        price = number * 1.1;
                    }
                    break;
                case "sweets":
                    if (city == "Sofia")
                    {
                        price = number * 1.45;
                    }
                    else if (city == "Plovdiv")
                    {
                        price = number * 1.3;
                    }
                    else if (city == "Varna")
                    {
                        price = number * 1.35;
                    }
                    break;
                case "peanuts":
                    if (city == "Sofia")
                    {
                        price = number * 1.6;
                    }
                    else if (city == "Plovdiv")
                    {
                        price = number * 1.5;
                    }
                    else if (city == "Varna")
                    {
                        price = number * 1.55;
                    }
                    break;
                    
            }
            Console.WriteLine(price);
        }
    }
}
