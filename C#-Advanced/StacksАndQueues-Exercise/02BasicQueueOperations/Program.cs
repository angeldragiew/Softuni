using System;
using System.Collections.Generic;
using System.Linq;

namespace _01BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int elementsToEnque = commands[0];
            int elementsToDeque = commands[1];
            int searchedElement = commands[2];

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(numbers);

            for (int i = 0; i < elementsToDeque; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(searchedElement))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count > 0)
            {
                int minValue = int.MaxValue;

                for (int i = 0; i < queue.Count; i++)
                {
                    if (queue.Peek() < minValue)
                    {
                        minValue = queue.Peek();
                    }
                    queue.Dequeue();
                }
                Console.WriteLine(minValue);
            }
            else
            {
                Console.WriteLine("0");
            }

        }
    }
}
