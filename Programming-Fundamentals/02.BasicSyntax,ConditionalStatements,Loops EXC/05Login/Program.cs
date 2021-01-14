using System;

namespace _05Login
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string username = Console.ReadLine();

            char[] passwordReverse = username.ToCharArray();
            Array.Reverse(passwordReverse);

            string password = new string(passwordReverse);
            string guess = Console.ReadLine();
            int tries = 0;

            while (true)
            {
                if (guess == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                else
                {
                    tries++;
                    if (tries > 3)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        break;
                    }

                    Console.WriteLine("Incorrect password. Try again.");
                }
                guess = Console.ReadLine();
            }
        }
    }
}
