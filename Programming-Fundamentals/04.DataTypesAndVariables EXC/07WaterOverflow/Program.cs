using System;

namespace _07WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int capacity = 255;
            int water = 0;
            for (int i = 1; i <= n; i++)
            {
                int litres = int.Parse(Console.ReadLine());
                if (litres > capacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    capacity -= litres;
                    water += litres;
                }
            }

            Console.WriteLine(water);
        }
    }
}
