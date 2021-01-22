using System;
using System.Collections.Generic;
using System.Linq;

namespace _03MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int queriesCount = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < queriesCount; i++)
            {
                int[] cmdArgs = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int command = cmdArgs[0];
                if (command == 1)
                {
                    int element = cmdArgs[1];
                    stack.Push(element);
                }
                else if (command == 2)
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else if (command == 3 && stack.Count > 0)
                {
                    Console.WriteLine(stack.Max());    
                }
                else if (command == 4 && stack.Count > 0)
                {
                  Console.WriteLine(stack.Min());
                }
            }

            Console.WriteLine(string.Join(", ", stack.ToList()));
        }
    }
}
