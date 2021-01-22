using System;
using System.Collections.Generic;
using System.Linq;

namespace _12CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bottlesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> cups = new Queue<int>(cupsInput);
            Stack<int> bottles = new Stack<int>(bottlesInput);

            int wastedWater = 0;

            int currBottle = 0;
            int currCup = 0;

            while (cups.Any() && bottles.Any())
            {
                if (currBottle <= 0)
                {
                    currBottle = bottles.Pop();
                }
                if (currCup <= 0)
                {
                    currCup = cups.Peek();
                }

                if (currCup <= currBottle)
                {
                    wastedWater += currBottle - currCup;
                    currCup -= currBottle;
                    cups.Dequeue();
                }
                else
                {
                    currCup -= currBottle;
                }
                currBottle = 0;
            }
            if (bottles.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else if (cups.Any())
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }


            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
