using System;
using System.Collections.Generic;
using System.Text;

namespace _04PizzaCalories
{
    public class Topping
    {
        private const double minToppingWeight = 1;
        private const double maxToppingWeight = 50;
        private const double baseCaloriesPerGram = 2;

        private Dictionary<string, double> types = new Dictionary<string, double>()
        {
            {"meat", 1.2 },
            {"veggies", 0.8 },
            {"sauce", 0.9 },
            {"cheese", 1.1 }
        };

        private double weightInGrams;
        private string type;
        private double calories;

        public Topping(string type, double grams)
        {
            Type = type;
            WeightInGrams = grams;
            calories = baseCaloriesPerGram * weightInGrams * types[type.ToLower()];
        }

        public string Type
        {
            get { return type; }
            private set
            {
                if (types.ContainsKey(value.ToLower()) == false)
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }
        public double WeightInGrams
        {
            get { return weightInGrams; }
            private set
            {
                if (value < minToppingWeight || value > maxToppingWeight)
                {
                    throw new ArgumentException($"{type} weight should be in the range [1..50].");
                }
                weightInGrams = value;
            }
        }

        public double Calories
        {
            get { return calories; }
        }
    }
}
