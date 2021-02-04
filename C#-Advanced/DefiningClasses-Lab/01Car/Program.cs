using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car skoda = new Car();
            skoda.Make = "VW";
            skoda.Model = "Octavia";
            skoda.Year = 2000;

            Console.WriteLine($"{skoda.Make}, {skoda.Model}, {skoda.Year}");
        }
    }
}
