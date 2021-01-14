using System;
using System.Collections.Generic;

namespace _02AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string resource = Console.ReadLine();
            

            Dictionary<string, int> loot = new Dictionary<string, int>();

            while (resource!= "stop")
            {
                int quantity = int.Parse(Console.ReadLine());
                if (loot.ContainsKey(resource))
                {
                    loot[resource] += quantity;
                }
                else
                {
                    loot.Add(resource, quantity);
                }

                resource = Console.ReadLine();
            }

            foreach (var item in loot)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
