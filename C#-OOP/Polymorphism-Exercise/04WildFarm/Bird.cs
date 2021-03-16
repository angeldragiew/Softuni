using System;
using System.Collections.Generic;
using System.Text;

namespace _04WildFarm
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, double weightIncreasePerPiece, double wingSize, HashSet<string> eatenFoods)
            : base(name, weight, weightIncreasePerPiece, eatenFoods)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {WingSize}, {this.GetWeight()}, {FoodEaten}]";
        }
    }
}
