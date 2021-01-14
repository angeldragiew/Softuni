using System;
using System.Collections.Generic;
using System.Linq;

namespace _03PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, RarityAndRating> plants = new Dictionary<string, RarityAndRating>();

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split("<->");
                string name = cmdArgs[0];
                int rarity = int.Parse(cmdArgs[1]);

                if (plants.ContainsKey(name))
                {
                    plants[name].Rarity = rarity;
                }
                else
                {
                    plants.Add(name, new RarityAndRating { Rarity = rarity ,Rating=0});
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "Exhibition")
            {
                string[] cmdArgs = input.Split(":");
                string command = cmdArgs[0];

                if (command == "Rate")
                {
                    string cmd = cmdArgs[1].Replace(" ", "");
                    string[] cmd2 = cmd.Split("-");
                    string name = cmd2[0];
                    double rating = double.Parse(cmd2[1]);

                    if (plants.ContainsKey(name))
                    {
                        if (plants[name].Rating == 0)
                        {
                            plants[name].Rating += rating;
                        }
                        else
                        {
                            plants[name].Rating += rating;
                            plants[name].Rating /=2;
                        }        
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command == "Update")
                {
                    string cmd = cmdArgs[1].Replace(" ", "");
                    string[] cmd2 = cmd.Split("-");
                    string name = cmd2[0];
                    int rarity = int.Parse(cmd2[1]);

                    if (plants.ContainsKey(name))
                    {
                        plants[name].Rarity = rarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command == "Reset")
                {
                    string cmd = cmdArgs[1].Replace(" ", "");
                    string[] cmd2 = cmd.Split("-");
                    string name = cmd2[0];

                    plants[name].Rating = 0;
                }


            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (var item in plants.OrderByDescending(r=>r.Value.Rarity).ThenByDescending(r=>r.Value.Rating))
            {
                Console.WriteLine($"- {item.Key}; Rarity: {item.Value.Rarity}; Rating: {item.Value.Rating:f2}");
            }
        }

        class RarityAndRating
        {
            public int Rarity { get; set; }
            public double Rating { get; set; }
        }
    }
}
