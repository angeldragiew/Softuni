using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double puzzle = 2.60;
            double talkingDow = 3;
            double bear = 4.10;
            double minion = 8.20;
            double truck = 2;

            double holidayPrice = double.Parse(Console.ReadLine());
            double puzzleNumber = double.Parse(Console.ReadLine());
            double talkingDowNumber = double.Parse(Console.ReadLine());
            double bearNumber = double.Parse(Console.ReadLine());
            double minionNumber = double.Parse(Console.ReadLine());
            double truckNumber = double.Parse(Console.ReadLine());

            double toysNumber = puzzleNumber + talkingDowNumber + bearNumber + minionNumber + truckNumber;
            double totalToysPrice = puzzleNumber* puzzle + talkingDowNumber* talkingDow + bearNumber* bear + minionNumber* minion + truckNumber* truck;

            if (toysNumber > 50)
            {
                totalToysPrice -= totalToysPrice * 0.25;
            }
            totalToysPrice -= totalToysPrice * 0.10;
            if(totalToysPrice>= holidayPrice)
            {
                double moneyLeft = totalToysPrice - holidayPrice;
                Console.WriteLine($"Yes! {moneyLeft} lv left.");
            }
            else
            {
                double moneyNeeded = holidayPrice - totalToysPrice;
                Console.WriteLine($"Not enough money! {moneyNeeded} lv needed.");
            }
        }
    }
}
