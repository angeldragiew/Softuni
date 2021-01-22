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

            int elementsToPush = commands[0];
            int elementsToPop = commands[1];
            int searchedElement = commands[2];

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(searchedElement))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count > 0)
            {
                int minValue = int.MaxValue;

                for (int i = 0; i < stack.Count; i++)
                {
                    if (stack.Peek() < minValue)
                    {
                        minValue = stack.Peek();
                    }
                    stack.Pop();
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
