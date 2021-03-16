using System;
using System.Collections.Generic;
using System.Text;

namespace _04WildFarm
{
    public class Owl : Bird
    {
        private const double weightIncreasePerPiece = 0.25;
        private static HashSet<string> eatenFoods = new HashSet<string>() { nameof(Meat) };
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, weightIncreasePerPiece, wingSize, eatenFoods)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
