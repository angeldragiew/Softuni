using System;
using System.Collections.Generic;
using System.Linq;

namespace _04FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] ordersInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int biggestOrder = int.MinValue;
            for (int i = 0; i < ordersInput.Length; i++)
            {
                if (ordersInput[i] > biggestOrder)
                {
                    biggestOrder = ordersInput[i];
                }
            }
            Console.WriteLine(biggestOrder);
            
            Queue<int> orders = new Queue<int>(ordersInput);

            bool ordersCompleted = true;
            while (orders.Count>0)
            {
                if (orders.Peek() <= foodQuantity)
                {
                    foodQuantity -= orders.Dequeue();
                }
                else
                {
                    ordersCompleted = false;
                    break;
                }
            }

            if (ordersCompleted)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders.ToList())}");
            }
        }
    }
}
