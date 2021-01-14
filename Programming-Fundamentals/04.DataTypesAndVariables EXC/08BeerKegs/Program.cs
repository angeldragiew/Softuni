using System;

namespace _08BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double volume = 0;
            string champion = string.Empty;
            for (int i = 1; i <= n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                double currKegVolume = Math.PI * Math.Pow(radius, 2) * height;

                if (currKegVolume > volume)
                {
                    volume = currKegVolume;
                    champion = model;
                }
            }

            Console.WriteLine(champion);
        }
    }
}
