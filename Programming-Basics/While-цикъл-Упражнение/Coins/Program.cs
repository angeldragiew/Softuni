using System;

namespace Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());
            change *= 100;
            int cent = Convert.ToInt32(change);


            int coins = 0;

            while (cent>0)
            {
                if (cent - 200 >= 0)
                {
                    cent -= 200;
                    coins++;
                    continue;
                }
                else if (cent - 100 >= 0)
                {
                    cent -= 100;
                    coins++;
                    continue;
                }
                else if (cent - 50 >= 0)
                {
                    cent -= 50;
                    coins++;
                    continue;
                }
                else if (cent - 20 >= 0)
                {
                    cent -= 20;
                    coins++;
                    continue;
                }
                else if (cent - 10 >= 0)
                {
                    cent -= 10;
                    coins++;
                    continue;
                }
                else if (cent - 5 >= 0)
                {
                    cent -= 5;
                    coins++;
                    continue;
                }
                else if (cent - 2>= 0)
                {
                    cent -= 2;
                    coins++;
                    continue;
                }
                else if (cent - 1 >= 0)
                {
                    cent -= 1;
                    coins++;
                    continue;
                }
            }

            Console.WriteLine(coins);
        }
    }
}
