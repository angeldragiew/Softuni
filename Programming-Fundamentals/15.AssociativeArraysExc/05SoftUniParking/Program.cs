using System;
using System.Collections.Generic;
using System.Linq;

namespace _05SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> parking = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split()
                    .ToArray();
                string command = cmdArgs[0];

                if (command == "register")
                {
                    string username = cmdArgs[1];
                    string plateNum = cmdArgs[2];

                    if (parking.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {plateNum}");
                    }
                    else
                    {
                        parking.Add(username, plateNum);
                        Console.WriteLine($"{username} registered {plateNum} successfully");
                    }
                }
                else
                {
                    string username = cmdArgs[1];
                    if (parking.ContainsKey(username))
                    {
                        parking.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                }
            }

            foreach (var user in parking)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
