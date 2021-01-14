using System;

namespace _10PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            decimal fiftyPercent = pokePower * 0.50M;

            int count = 0;
            while (pokePower >= distance)
            {

                count++;
                pokePower -= distance;
                if (pokePower == fiftyPercent && exhaustionFactor != 0)
                { 
                    pokePower /= exhaustionFactor;
                }           
            }

            Console.WriteLine(pokePower);
            Console.WriteLine(count);
        }
    }
}
