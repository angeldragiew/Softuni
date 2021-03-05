using System;

namespace _01ClassBoxData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double l = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(l, w, h);
                Console.WriteLine($"Surface Area - {box.CalculateSurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.CalculateLateralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {box.CalculateVolume():f2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
