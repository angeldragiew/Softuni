using System;

namespace _07ConcatNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string fName = Console.ReadLine();
            string lName = Console.ReadLine();

            string delimiter = Console.ReadLine();

            string all = fName + delimiter + lName;
            Console.WriteLine(all);
        }
    }
}
