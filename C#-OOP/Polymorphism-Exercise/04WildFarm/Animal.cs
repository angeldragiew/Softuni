using System;
using System.Collections.Generic;
using System.Text;

namespace _04WildFarm
{
    public abstract class Animal
    {
        public Animal(string name, double weight, double weightIncreasePerPiece, HashSet<string> eatenFoods)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
            WeightIncreasePerPiece = weightIncreasePerPiece;
            EatenFoods = eatenFoods;
        }

        public double WeightIncreasePerPiece { get; private set; }
        public HashSet<string> EatenFoods { get; private set; }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        public abstract string ProduceSound();

        public void Eat(Food food)
        {
            if (EatenFoods.Contains(food.GetType().Name))
            {
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat { food.GetType().Name}!");
            }
        }

        protected double GetWeight()
        {
            return Weight + (WeightIncreasePerPiece * FoodEaten);
        }
    }
}
