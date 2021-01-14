using System;
using System.Collections.Generic;
using System.Linq;

namespace _02Loot
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> loot = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input;

            while ((input = Console.ReadLine()) != "Yohoho!")
            {
                string[] cmdArgs = input.Split();

                string command = cmdArgs[0];

                if (command == "Loot")
                {
                    for (int i = 1; i < cmdArgs.Length; i++)
                    {
                        if (!isItemExist(cmdArgs[i], loot))
                        {
                            loot.Insert(0, cmdArgs[i]);
                        }
                    }
                }
                else if (command == "Drop")
                {
                    int index = int.Parse(cmdArgs[1]);

                    if (index >= 0 && index < loot.Count)
                    {
                        string item = loot[index];
                        loot.RemoveAt(index);
                        loot.Add(item);
                    }
                }
                else if (command == "Steal")
                {
                    int count = int.Parse(cmdArgs[1]);
                    List<string> stolenItems = new List<string>();
                    for (int i = loot.Count-1; i >= 0; i--)
                    {
                        count--;
                        stolenItems.Insert(0, loot[i]);
                        loot.RemoveAt(i);
                        if (count == 0)
                        {
                            break;
                        }
                        
                    }
                    Console.WriteLine(string.Join(", ", stolenItems));
                }
            }
            if (loot.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                double gain = 0;
                for (int i = 0; i < loot.Count; i++)
                {
                    gain += loot[i].Length;
                }
                double averageGain = gain / loot.Count;

                Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
            }
            
        }
        static bool isItemExist(string item, List<string> Items)
        {
            return Items.Any(i => i == item);
        }
    }
}
