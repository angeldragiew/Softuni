using System;
using System.Collections.Generic;
using System.Linq;

namespace _03LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            string legendaryItem = "";

            Dictionary<string, int> items = new Dictionary<string, int>();
            items.Add("shards", 0);
            items.Add("fragments", 0);
            items.Add("motes", 0);

            while (true)
            {
                string[] arr = Console.ReadLine()
                    .Split()
                    .ToArray();

                for (int i = 0; i < arr.Length; i += 2)
                {
                    int quantity = int.Parse(arr[i]);
                    if (items.ContainsKey(arr[i + 1].ToLower()))
                    {
                        items[arr[i + 1].ToLower()] += quantity;
                        if (items["shards"] >= 250)
                        {
                            legendaryItem = "Shadowmourne";
                            items["shards"] -= 250;
                            goto EndOfCycle;
                        }
                        else if (items["fragments"] >= 250)
                        {
                            legendaryItem = "Valanyr";
                            items["fragments"] -= 250;
                            goto EndOfCycle;
                        }
                        else if (items["motes"] >= 250)
                        {
                            legendaryItem = "Dragonwrath";
                            items["motes"] -= 250;
                            goto EndOfCycle;
                        }

                    }
                    else
                    {
                        items.Add(arr[i + 1].ToLower(), quantity);
                    }
                }

            }
            EndOfCycle:
            Dictionary<string, int> legendaryItems = items.Where(x => x.Key == "shards" ||
                                                                    x.Key == "fragments" ||
                                                                    x.Key == "motes")
                                                                    .OrderByDescending(x => x.Value)
                                                                    .ThenBy(x => x.Key)
                                                                    .ToDictionary(x => x.Key, x => x.Value);

            Dictionary<string, int> garbage = items.Where(x => x.Key != "shards" &&
                                                                    x.Key != "fragments" &&
                                                                    x.Key != "motes")
                                                                    .OrderBy(x => x.Key)
                                                                    .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"{legendaryItem} obtained!");
            foreach (var item in legendaryItems)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in garbage)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
