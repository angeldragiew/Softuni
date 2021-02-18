using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> foods = new Dictionary<string, int>()
            {
                {"Bread", 0 },
                {"Cake", 0 },
                {"Pastry", 0 },
                {"Fruit Pie", 0 }
            };
            int[] liquidInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] ingredientsInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> liquids = new Queue<int>(liquidInfo);
            Stack<int> ingredients = new Stack<int>(ingredientsInfo);

            while (liquids.Any() && ingredients.Any())
            {
                int currLiquid = liquids.Dequeue();
                int currIngredient = ingredients.Pop();

                int sum = currIngredient + currLiquid;
                string foodToAdd = string.Empty;
                if (sum == 25)
                {
                    foodToAdd = "Bread";
                }
                else if (sum == 50)
                {
                    foodToAdd = "Cake";
                }
                else if (sum == 75)
                {
                    foodToAdd = "Pastry";
                }
                else if (sum == 100)
                {
                    foodToAdd = "Fruit Pie";
                }
                else
                {
                    currIngredient += 3;
                    ingredients.Push(currIngredient);
                    continue;
                }

                foods[foodToAdd]++;
            }

            bool isCookedEverything = true;
            foreach (var food in foods)
            {
                if (food.Value == 0)
                {
                    isCookedEverything = false;
                    break;
                }
            }

            if (isCookedEverything)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Any())
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            foreach (var food in foods.OrderBy(f => f.Key))
            {
                Console.WriteLine($"{food.Key}: {food.Value}");
            }
        }
    }
}
