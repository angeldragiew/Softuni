using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstBoxInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondBoxInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> firstBox = new Queue<int>(firstBoxInfo);
            Stack<int> secondBox = new Stack<int>(secondBoxInfo);

            int loot = 0;
            while (firstBox.Any() && secondBox.Any())
            {
                int firstValue = firstBox.Peek();
                int secondValue = secondBox.Peek();

                int sum = firstValue + secondValue;

                if (sum % 2 == 0)
                {
                    loot += sum;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    int value = secondBox.Pop();
                    firstBox.Enqueue(value);
                }
            }

            if (firstBox.Any() == false)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (loot >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {loot}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {loot}");
            }
        }
    }
}
