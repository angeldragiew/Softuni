using System;

namespace _07VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            double nuts = 2;
            double water = 0.7;
            double crisps = 1.5;
            double soda = 0.8;
            double coke = 1.0;

            string input = Console.ReadLine();

            double totalMoney =0;
            while (input!="Start")
            {
                double money = double.Parse(input);

                switch (money)
                {
                    case 0.1:
                    case 0.2:
                    case 0.5:
                    case 1:
                    case 2:
                        totalMoney += money;
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {money}");
                        break;
                }
                input = Console.ReadLine();
            }


            string product = Console.ReadLine();
            while (product!="End")
            {
                switch (product)
                {
                    case "Nuts":
                        if (totalMoney >= nuts)
                        {
                            totalMoney -= nuts;
                            Console.WriteLine($"Purchased {product.ToLower()}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Water":
                        if (totalMoney >= water)
                        {
                            totalMoney -= water;
                            Console.WriteLine($"Purchased {product.ToLower()}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Crisps":
                        if (totalMoney >= crisps)
                        {
                            totalMoney -= crisps;
                            Console.WriteLine($"Purchased {product.ToLower()}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Soda":
                        if (totalMoney >= soda)
                        {
                            totalMoney -= soda;
                            Console.WriteLine($"Purchased {product.ToLower()}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Coke":
                        if (totalMoney >= coke)
                        {
                            totalMoney -= coke;
                            Console.WriteLine($"Purchased {product.ToLower()}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }
                product = Console.ReadLine();
            }
            Console.WriteLine($"Change: {totalMoney:f2}");
        }
    }
}
