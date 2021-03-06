using System;
using System.Collections.Generic;
using System.Text;

namespace _04PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            toppings = new List<Topping>();
            Name = name;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if(string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }

        public Dough Dough
        {
            get { return dough; }
            set
            {
                dough = value;
            }
        }
        public int NumberOfToppings => toppings.Count;

        public void AddTopping(Topping topping)
        {
            if (toppings.Count >= 10)
            {
                throw new InvalidOperationException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }

        public double GetTotalCalories()
        {
            double totalCalories = 0;

            foreach (var topping in toppings)
            {
                totalCalories += topping.Calories;
            }
            totalCalories += dough.Calories;
            return totalCalories;
        }

        public override string ToString()
        {
            return $"{Name} - {GetTotalCalories():f2} Calories.";
        }
    }
}
