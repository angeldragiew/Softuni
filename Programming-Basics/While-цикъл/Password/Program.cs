using System;

namespace Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string password = Console.ReadLine();
            string inputPassword = Console.ReadLine();

            while (password!= inputPassword)
            {
                inputPassword = Console.ReadLine();
            }

            Console.WriteLine($"Welcome {name}!");
        }
    }
}
