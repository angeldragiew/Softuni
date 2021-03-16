using System;
using System.Collections.Generic;
using System.Text;

namespace _04WildFarm
{
    public class Mouse : Mammal
    {
        private const double weightIncreasePerPiece = 0.10;
        private static HashSet<string> eatenFoods = new HashSet<string>() { nameof(Vegetable), nameof(Fruit) };
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, weightIncreasePerPiece, livingRegion,eatenFoods)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {this.GetWeight()}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
