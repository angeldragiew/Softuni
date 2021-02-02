using System;

namespace _02KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> printNames = n =>
            {
                foreach (var name in n)
                {
                    Console.WriteLine($"Sir {name}");
                }
            };

            printNames(names);
        }
    }
}
