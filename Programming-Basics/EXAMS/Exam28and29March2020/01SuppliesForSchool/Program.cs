using System;

namespace _01SuppliesForSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double penPackage = 5.80;
            double markerPackage = 7.20;
            double preparation = 1.20;

            int penPackagesCount = int.Parse(Console.ReadLine());
            int markerPackagesCount = int.Parse(Console.ReadLine());
            double preparationLitres = double.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());
            discount /= 100;

            double sum = penPackagesCount * penPackage + markerPackagesCount * markerPackage + preparationLitres * preparation;
            sum *= 1.00 - discount;

            Console.WriteLine($"{sum:f3}");

        }
    }
}
