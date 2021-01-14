using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _03Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input;

            while ((input = Console.ReadLine()) != "Craft!")
            {
                string[] cmdArgs = input.Split(" - ").ToArray();

                string command = cmdArgs[0];

                if (command == "Collect")
                {
                    string item = cmdArgs[1];
                    if (isItemExist(item, items))
                    {
                        continue;
                    }
                    else
                    {
                        items.Add(item);
                    }
                }
                else if (command == "Drop")
                {
                    string item = cmdArgs[1];
                    if (isItemExist(item, items))
                    {
                        items.Remove(item);
                    }
                    else
                    {
                        continue;
                    }
                } else if (command == "Combine Items")
                {
                    string[] itemsToCombine = cmdArgs[1].Split(":").ToArray();

                    string oldItem = itemsToCombine[0];
                    string newItem = itemsToCombine[1];

                    int idexOfNewdItem = items.IndexOf(oldItem)+1;

                    if (isItemExist(oldItem, items))
                    {
                        items.Insert(idexOfNewdItem, newItem);
                    }
                    else
                    {
                        continue;
                    }
                }else if(command == "Renew")
                {
                    string item = cmdArgs[1];
                    if (isItemExist(item, items))
                    {
                        items.Remove(item);
                        items.Add(item);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            Console.WriteLine(string.Join(", ", items));

        }
        static bool isItemExist(string item, List<string> Items)
        {
            return Items.Any(i => i == item);
        }
    }
}

