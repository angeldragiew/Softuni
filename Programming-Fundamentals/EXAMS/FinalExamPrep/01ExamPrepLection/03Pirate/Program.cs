using System;
using System.Collections.Generic;
using System.Linq;

namespace _03Pirate
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, CityPopulationAndGold> cities = new Dictionary<string, CityPopulationAndGold>();
            string input;
            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] cmdArgs = input.Split("||", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = cmdArgs[0];
                int population = int.Parse(cmdArgs[1]);
                int gold = int.Parse(cmdArgs[2]);

                if (cities.ContainsKey(name))
                {
                    cities[name].Gold += gold;
                    cities[name].Population += population;
                }
                else
                {
                    cities.Add(name, new CityPopulationAndGold { Population = population, Gold = gold });
                }

            }

            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = input.Split("=>", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = cmdArgs[0];

                if (command == "Plunder")
                {
                    string name = cmdArgs[1];
                    int population = int.Parse(cmdArgs[2]);
                    int gold = int.Parse(cmdArgs[3]);
                    cities[name].Gold -= gold;
                    cities[name].Population -= population;
                    Console.WriteLine($"{name} plundered! {gold} gold stolen, {population} citizens killed.");
                    if (cities[name].Gold <= 0 || cities[name].Population <= 0)
                    {
                        cities.Remove(name);
                        Console.WriteLine($"{name} has been wiped off the map!");
                    }
                }
                else
                {
                    //•	"Prosper=>{town}=>{gold}"
                    string name = cmdArgs[1];
                    int gold = int.Parse(cmdArgs[2]);
                    if (gold > 0)
                    {
                        cities[name].Gold += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {name} now has {cities[name].Gold} gold.");
                    }
                    else
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                }

            }

            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (var item in cities.OrderByDescending(g=>g.Value.Gold).ThenBy(n=>n.Key))
                {
                    Console.WriteLine($"{item.Key} -> Population: {item.Value.Population} citizens, Gold: {item.Value.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }

        class CityPopulationAndGold
        {
            public int Population { get; set; }
            public int Gold { get; set; }
        }
    }
}
