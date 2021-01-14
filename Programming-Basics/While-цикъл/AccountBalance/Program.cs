using System;

namespace AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalMoney = 0;
            string input = Console.ReadLine();

            while (input!= "NoMoreMoney")
            {
                double sum = double.Parse(input);
                if (sum<0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                totalMoney += sum;
                Console.WriteLine($"Increase: {sum:f2}");
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total: {totalMoney:f2}");
        }
    }

}
