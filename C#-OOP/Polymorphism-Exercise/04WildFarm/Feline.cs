using System;
using System.Collections.Generic;
using System.Text;

namespace _04WildFarm
{
    public abstract class Feline : Mammal
    {

        protected Feline(string name, double weight, double weightIncreasePerPiece, string livingRegion, string breed,
            HashSet<string> eatenFoods)
            : base(name, weight, weightIncreasePerPiece, livingRegion, eatenFoods)
        {
            Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Breed}, {this.GetWeight()}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
