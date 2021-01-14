using System;

namespace _05SuitcasesLoad1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double trunk = double.Parse(Console.ReadLine());

            int suitcasesCount = 0;
            bool full = false;

            string input = Console.ReadLine();
            while (input!= "End")
            {
                suitcasesCount++;
                double suitcase = double.Parse(input);
                if (suitcasesCount % 3 == 0)
                {
                    suitcase *= 1.10;
                }
                trunk -= suitcase;
                if (trunk <= 0)
                {
                    suitcasesCount--;
                    full = true;
                    break;
                }
         
                input = Console.ReadLine();
            }

            if (full)
            {
                Console.WriteLine("No more space!");
            }
            else
            {
                Console.WriteLine("Congratulations! All suitcases are loaded!");
            }

            Console.WriteLine($"Statistic: {suitcasesCount} suitcases loaded.");
        }
    }
}
