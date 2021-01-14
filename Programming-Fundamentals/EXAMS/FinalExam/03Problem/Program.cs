using System;
using System.Collections.Generic;
using System.Linq;

namespace _03Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> users = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] cmdArgs = input.Split("->");

                string command = cmdArgs[0];

                if (command == "Add")
                {
                    string username = cmdArgs[1];

                    if (users.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} is already registered");
                    }
                    else
                    {
                        users.Add(username, new List<string> { });
                    }
                }
                else if (command == "Send")
                {
                    string username = cmdArgs[1];
                    string email = cmdArgs[2];

                    if (users.ContainsKey(username))
                    {
                        users[username].Add(email);
                    }
                    
                }
                else if (command == "Delete")
                {
                    string username = cmdArgs[1];

                    if (users.ContainsKey(username))
                    {
                        users.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} not found!");
                    }
                }
            }
            Console.WriteLine($"Users count: {users.Count}");

            foreach (var user in users.OrderByDescending(e=>e.Value.Count).ThenBy(u=>u.Key))
            {
                Console.WriteLine(user.Key);
                foreach (var email in user.Value)
                {
                    Console.WriteLine($" - {email}");
                }
            }

        }
    }
}
