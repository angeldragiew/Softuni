using System;
using System.Collections.Generic;
using System.Linq;

namespace _7HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();
            int n = int.Parse(Console.ReadLine());

            Queue<string> kids = new Queue<string>(input);
            int count = 0;

            while (kids.Count > 1)
            {
                count++;
                if (count == n)
                {
                    Console.WriteLine($"Removed {kids.Dequeue()}");
                    count = 0;
                }
                else
                {
                    kids.Enqueue(kids.Dequeue());
                }
            }
            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
