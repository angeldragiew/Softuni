using System;
using System.Collections.Generic;
using System.Linq;

namespace _01FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liliesInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] rosesInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> lilies = new Stack<int>(liliesInfo);
            Queue<int> roses = new Queue<int>(rosesInfo);

            int wreaths = 0;
            int storedFlowers = 0;
            int currLily = 0;
            int currRose = 0;
            while (lilies.Any() && roses.Any())
            {
                currLily = lilies.Peek();
                currRose = roses.Peek();

                int sum = currLily + currRose;
                if (sum == 15)
                {
                    wreaths++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (sum < 15)
                {
                    storedFlowers += sum;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else
                {
                    currLily -= 2;
                    lilies.Pop();
                    lilies.Push(currLily);
                }
            }

            wreaths += storedFlowers / 15;

            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}
