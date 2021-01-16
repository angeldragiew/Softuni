using System;
using System.Collections.Generic;
using System.Linq;

namespace _2StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> stackWithNums = new Stack<int>(numbers);

            string input;

            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] cmdArgs = input.Split();
                string command = cmdArgs[0];
                if (command.ToLower() == "add")
                {
                    int firstNum = int.Parse(cmdArgs[1]);
                    int secondNum = int.Parse(cmdArgs[2]);
                    stackWithNums.Push(firstNum);
                    stackWithNums.Push(secondNum);
                }
                else if (command.ToLower() == "remove")
                {
                    int count = int.Parse(cmdArgs[1]);
                    if (stackWithNums.Count > count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stackWithNums.Pop();
                        }
                    }
                }
            }

            int sum = 0;
            while (stackWithNums.Count > 0)
            {
                sum += stackWithNums.Pop();
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
