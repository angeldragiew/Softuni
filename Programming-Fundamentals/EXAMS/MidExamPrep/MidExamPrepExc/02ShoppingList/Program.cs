using System;
using System.Collections.Generic;
using System.Linq;

namespace _02ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shoppingList = Console.ReadLine()
                .Split("!", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input;

            while ((input = Console.ReadLine()) != "Go Shopping!")
            {
                string[] commandArgs = input.Split().ToArray();

                string command = commandArgs[0];

                if (command == "Urgent")
                {
                    string item = commandArgs[1];
                    bool alreadyExist = shoppingList.Any(product => product == item);

                    if (!alreadyExist)
                    {
                        shoppingList.Insert(0, item);
                    }
                }
                else if (command == "Unnecessary")
                {
                    string item = commandArgs[1];
                    bool alreadyExist = shoppingList.Any(product => product == item);

                    if (alreadyExist)
                    {
                        shoppingList.Remove(item);
                    }
                }
                else if (command == "Correct")
                {
                    string item = commandArgs[1];
                    string itemCorrectName = commandArgs[2];

                    bool alreadyExist = shoppingList.Any(product => product == item);

                    if (alreadyExist)
                    {
                        int index = shoppingList.IndexOf(item);
                        shoppingList[index] = itemCorrectName;

                    }
                }
                else if (command == "Rearrange")
                {
                    string item = commandArgs[1];

                    bool alreadyExist = shoppingList.Any(product => product == item);

                    if (alreadyExist)
                    {
                        shoppingList.Remove(item);
                        shoppingList.Add(item);
                    }
                }
            }
            Console.WriteLine(string.Join(", ", shoppingList));
        }
    }
}
