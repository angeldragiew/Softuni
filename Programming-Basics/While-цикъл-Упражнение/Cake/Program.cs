using System;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());

            int size = length * width;

            bool cakeLeft = false;
            string input = "";
            while (size>0)
            {
                input = Console.ReadLine();
                if (input == "STOP")
                {
                    cakeLeft = true;
                    break;
                }
                int pieces = int.Parse(input);
                size -= pieces;
                
            }

            if (cakeLeft)
            {
                Console.WriteLine($"{Math.Abs(size)} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(size)} pieces more.");
            }
        }
    }
}
