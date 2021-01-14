using System;
using System.Collections.Generic;
using System.Linq;

namespace _02ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input;
            int count = 0;
            while ((input = Console.ReadLine()) != "End")
            {
                int index = int.Parse(input);

                if (index >= 0 && index < targets.Count && targets[index] != -1)
                {
                    int originalValue = targets[index];
                    targets[index] = -1;
                    count++;
                    for (int i = 0; i < targets.Count; i++)
                    {
                        if(targets[i]<= originalValue && targets[i] != -1)
                        {
                            targets[i] += originalValue;
                        }
                        else if(targets[i] > originalValue && targets[i] != -1)
                        {
                            targets[i] -= originalValue;
                        }
                    }
                }
            }

            Console.WriteLine($"Shot targets: {count} -> {string.Join(" ", targets)}");
        }
    }
}
