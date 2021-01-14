using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double money = double.Parse(Console.ReadLine());

            string act = "";
            double sum = 0;
            
            int spendDaysCount = 0;
            bool isSaved = false;
            int days = 0;
            while (true)
            {
                act = Console.ReadLine();
                sum = double.Parse(Console.ReadLine());
                days++;
                if (act == "spend")
                {
                    spendDaysCount++;
                    money -= sum;
                    if (money < 0)
                    {
                        money = 0;
                    }

                    if (spendDaysCount == 5)
                    {
                        break;
                    }
                }
                else if (act == "save")
                {
                    spendDaysCount = 0;
                    money += sum;
                    if(money>= neededMoney)
                    {
                        isSaved = true;
                        break;
                    }
                }
                
            }
            if (isSaved)
            {
                Console.WriteLine($"You saved the money for {days} days.");
            }
            else
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(days);
            }
        }
    }
}
