using System;
using System.Collections.Generic;
using System.Linq;

namespace _03MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {

                string[] commandArgs = input.Split().ToArray();

                string command = commandArgs[0];

                if (command == "Shoot")
                {
                    int index = int.Parse(commandArgs[1]);
                    int power = int.Parse(commandArgs[2]);

                    if (index >= 0 && index < targets.Count)
                    {
                        targets[index] -= power;
                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                    }


                }
                else if (command == "Add")
                {
                    int index = int.Parse(commandArgs[1]);
                    int value = int.Parse(commandArgs[2]);

                    if (index >= 0 && index < targets.Count)
                    {
                        targets.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                }
                else if (command == "Strike")
                {
                    int index = int.Parse(commandArgs[1]);
                    int radius = int.Parse(commandArgs[2]);

                    int start = index - radius;
                    int end = index + radius;


                    if (start >= 0 && start < targets.Count && end >= 0 && end < targets.Count)
                    {
                        targets.RemoveRange(start, end - start + 1);
                    }
                    else
                    {
                        Console.WriteLine("Strike missed!");
                    }
                }

            }

            Console.WriteLine(string.Join("|", targets));
        }
    }
}
