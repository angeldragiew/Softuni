using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([#]|[|])(?<name>[A-Za-z ]+)\1(?<date>[\d]{2}\/[\d]{2}\/[\d]{2})\1(?<calories>[\d]+)\1";

            List<Food> foods = new List<Food>();

            string text = Console.ReadLine();

            MatchCollection matches = Regex.Matches(text, pattern);

            int totalCalories = 0;

            foreach (Match item in matches)
            {
                totalCalories += int.Parse(item.Groups["calories"].Value);

                string name = item.Groups["name"].Value;
                string date = item.Groups["date"].Value;

                int nutrition = int.Parse(item.Groups["calories"].Value);

                foods.Add(new Food { Name=name,Date=date,Nutrition=nutrition});
            }

            int days = totalCalories / 2000;
            Console.WriteLine($"You have food to last you for: {days} days!");
            foreach (var food in foods)
            {
                Console.WriteLine($"Item: {food.Name}, Best before: {food.Date}, Nutrition: {food.Nutrition}");
            }
        }

        class Food
        {
            public string Name { get; set; }
            public string Date { get; set; }
            public int Nutrition { get; set; }
        }
    }
}
