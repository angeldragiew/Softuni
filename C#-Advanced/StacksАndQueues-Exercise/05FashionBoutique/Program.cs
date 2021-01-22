using System;
using System.Collections.Generic;
using System.Linq;

namespace _05FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());
            int rack = rackCapacity;
            int neededRacks = 1;

            Stack<int> clothes = new Stack<int>(clothesInput);

            while (clothes.Any())
            {
                if (rack - clothes.Peek() >= 0)
                {
                    rack -= clothes.Pop();
                }
                else
                {
                    neededRacks++;
                    rack = rackCapacity;
                }
            }
            Console.WriteLine(neededRacks);
        }
    }
}
