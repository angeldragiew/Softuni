using System;
using System.Collections.Generic;

namespace _03HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = new List<string>();

            int numberOfComands = int.Parse(Console.ReadLine());
           
            for (int i = 0; i < numberOfComands; i++)
            {
                bool isAlreadyIn = false;
                string[] input = Console.ReadLine().Split();
                string name;
                if (input.Length == 3)
                {
                    name = input[0];
                    foreach (var guest in guests)
                    {
                        if (name == guest)
                        {
                            isAlreadyIn = true;
                            break;
                        }
                    }
                    if (isAlreadyIn)
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        guests.Add(name);
                    }
                }
                else
                {
                    name = input[0];
                    foreach (var guest in guests)
                    {
                        if (name == guest)
                        {
                            isAlreadyIn = true;
                            break;
                        }
                    }
                    if (isAlreadyIn)
                    {
                        guests.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
            }
            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
