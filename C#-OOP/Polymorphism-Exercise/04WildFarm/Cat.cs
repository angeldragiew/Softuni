using System;
using System.Collections.Generic;
using System.Text;

namespace _04WildFarm
{
    public class Cat : Feline
    {
        private const double weightIncreasePerPiece = 0.30;
        private static HashSet<string> eatenFoods = new HashSet<string>() { nameof(Meat), nameof(Vegetable) };
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, weightIncreasePerPiece, livingRegion, breed, eatenFoods)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
