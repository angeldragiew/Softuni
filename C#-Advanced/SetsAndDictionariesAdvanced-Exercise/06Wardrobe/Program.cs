using System;
using System.Collections.Generic;

namespace _06Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] colorAndClothes = Console.ReadLine().Split(" -> ");
                string color = colorAndClothes[0];
                string[] clothes = colorAndClothes[1].Split(",");

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                for (int z = 0; z < clothes.Length; z++)
                {
                    if (!wardrobe[color].ContainsKey(clothes[z]))
                    {
                        wardrobe[color].Add(clothes[z], 0);
                    }
                    wardrobe[color][clothes[z]]++;
                }

            }

            string[] searchedClothInfo = Console.ReadLine().Split();
            string searchedColor = searchedClothInfo[0];
            string searchedCloth = searchedClothInfo[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var cloth in color.Value)
                {
                    Console.Write($"* {cloth.Key} - {cloth.Value}");
                    if (color.Key == searchedColor && cloth.Key == searchedCloth)
                    {
                        Console.Write(" (found!)");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
