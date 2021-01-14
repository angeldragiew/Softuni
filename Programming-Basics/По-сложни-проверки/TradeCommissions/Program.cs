using System;

namespace TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double s = double.Parse(Console.ReadLine());
            double comission = 0;
            switch (city)
            {
                case "Sofia":
                    if(0<=s && s <= 500)
                    {
                        comission = 5;
                        Console.WriteLine($"{s*(comission/100):f2}");
                    }else if(500<s && s <= 1000)
                    {
                        comission = 7;
                        Console.WriteLine($"{s * (comission / 100):f2}");
                    }
                    else if (1000 < s && s <= 10000)
                    {
                        comission = 8;
                        Console.WriteLine($"{s * (comission / 100):f2}");
                    }
                    else if (s>10000)
                    {
                        comission = 12;
                        Console.WriteLine($"{s * (comission / 100):f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                case "Varna":
                    if (0 <= s && s <= 500)
                    {
                        comission = 4.5;
                        Console.WriteLine($"{s * (comission / 100):f2}");
                    }
                    else if (500 < s && s <= 1000)
                    {
                        comission = 7.5;
                        Console.WriteLine($"{s * (comission / 100):f2}");
                    }
                    else if (1000 < s && s <= 10000)
                    {
                        comission = 10;
                        Console.WriteLine($"{s * (comission / 100):f2}");
                    }
                    else if (s > 10000)
                    {
                        comission = 13;
                        Console.WriteLine($"{s * (comission / 100):f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                case "Plovdiv":
                    if (0 <= s && s <= 500)
                    {
                        comission = 5.5;
                        Console.WriteLine($"{s * (comission / 100):f2}");
                    }
                    else if (500 < s && s <= 1000)
                    {
                        comission = 8;
                        Console.WriteLine($"{s * (comission / 100):f2}");
                    }
                    else if (1000 < s && s <= 10000)
                    {
                        comission = 12;
                        Console.WriteLine($"{s * (comission / 100):f2}");
                    }
                    else if (s > 10000)
                    {
                        comission = 14.5;
                        Console.WriteLine($"{s * (comission / 100):f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                default:
                    Console.WriteLine("error");
                    break;

            }
        }
    }
}
