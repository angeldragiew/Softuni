using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace _02MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> rooms = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            bool success = true;

            int health = 100;
            int bitcoins = 0;
            int bestRoom = 0;
            for (int i = 0; i < rooms.Count; i++)
            {
                string[] cmdArgs = rooms[i].Split().ToArray();
                string command = cmdArgs[0];
                int number = int.Parse(cmdArgs[1]);
                bestRoom++;
                switch (command)
                {
                    case "potion":
                        health += number;
                        int generatedHealth = number;
                        if (health > 100)
                        {
                            generatedHealth = number - (health - 100);
                            health = 100;
                        }

                        Console.WriteLine($"You healed for {generatedHealth} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                        break;
                    case "chest":
                        bitcoins += number;
                        Console.WriteLine($"You found {number} bitcoins.");
                        break;
                    default:
                        health -= number;

                        if (health > 0)
                        {
                            Console.WriteLine($"You slayed {command}.");
                        }
                        else
                        {
                            Console.WriteLine($"You died! Killed by {command}.");
                            Console.WriteLine($"Best room: {bestRoom}");
                            success = false;
                            
                        }
                        break;
                }
                if (!success)
                {
                    break;
                }
            }

            if (success)
            {
                Console.WriteLine($"You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}
