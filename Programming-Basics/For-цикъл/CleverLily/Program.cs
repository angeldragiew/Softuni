using System;

namespace CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachine = double.Parse(Console.ReadLine());
            double toyPrice = double.Parse(Console.ReadLine());

            int toys = 0;
            double totalMoney = 0;
            double moneyForBirthDay = 10;


            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    totalMoney += moneyForBirthDay;
                    moneyForBirthDay += 10;
                    totalMoney -= 1;
                }
                else
                {
                    toys++;
                }
            }

            totalMoney += toys * toyPrice;

            if (totalMoney >= washingMachine)
            {
                Console.WriteLine($"Yes! {totalMoney-washingMachine:f2}");
            }
            else
            {
                Console.WriteLine($"No! {washingMachine-totalMoney:f2}");
            }
        }
    }
}
