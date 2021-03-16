using System;
using System.Collections.Generic;
using System.Text;

namespace _04WildFarm
{
    public class Tiger : Feline
    {
        private const double weightIncreasePerPiece = 1;
        private static HashSet<string> eatenFoods = new HashSet<string>() { nameof(Meat) };
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, weightIncreasePerPiece, livingRegion, breed, eatenFoods)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
