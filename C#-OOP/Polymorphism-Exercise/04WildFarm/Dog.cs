using System;
using System.Collections.Generic;
using System.Text;

namespace _04WildFarm
{
    public class Dog : Mammal
    {
        private const double weightIncreasePerPiece = 0.40;
        private static HashSet<string> eatenFoods = new HashSet<string>() { nameof(Meat)};
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, weightIncreasePerPiece, livingRegion, eatenFoods)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {this.GetWeight()}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
