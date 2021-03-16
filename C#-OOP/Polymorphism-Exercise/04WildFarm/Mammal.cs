using System;
using System.Collections.Generic;
using System.Text;

namespace _04WildFarm
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, double weightIncreasePerPiece, string livingRegion, HashSet<string> eatenFoods)
            : base(name, weight, weightIncreasePerPiece, eatenFoods)
        {
            LivingRegion = livingRegion;
        }
       
        public string LivingRegion { get; private set; }
    }
}
