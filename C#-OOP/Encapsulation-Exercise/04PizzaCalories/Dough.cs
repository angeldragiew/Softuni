using System;
using System.Collections.Generic;
using System.Text;

namespace _04PizzaCalories
{
    public class Dough
    {
        private const double minDoughWeight = 1;
        private const double maxDoughWeight = 200;

        private const double doughtCaloriesPerGram = 2;

        private Dictionary<string, double> flourTypes = new Dictionary<string, double>()
        {
            {"white",  1.5},
            {"wholegrain",1 }
        };

        private Dictionary<string, double> bakingTechniques = new Dictionary<string, double>()
        {
            {"crispy",  0.9},
            {"chewy",1.1 },
            {"homemade", 1 }
        };
        private string flourType;
        private string bakingTechnique;
        private double weightInGrams;
        private double calories;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            WeightInGrams = grams;
            this.calories = doughtCaloriesPerGram * weightInGrams * flourTypes[flourType.ToLower()] * bakingTechniques[bakingTechnique.ToLower()];
        }

        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (flourTypes.ContainsKey(value.ToLower()) == false)
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }
        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set
            {
                if (bakingTechniques.ContainsKey(value.ToLower()) == false)
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }
        public double WeightInGrams
        {
            get { return weightInGrams; }
            private set
            {
                if (value < minDoughWeight || value > maxDoughWeight)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weightInGrams = value;
            }
        }

        public double Calories
        {
            get
            {
                return calories;
            }
        }

    }
}
