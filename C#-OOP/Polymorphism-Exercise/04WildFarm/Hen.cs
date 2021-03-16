using System;
using System.Collections.Generic;
using System.Text;

namespace _04WildFarm
{
    public class Hen : Bird
    {
        private const double weightIncreasePerPiece = 0.35;
        private static HashSet<string> eatenFoods = new HashSet<string>() { nameof(Vegetable), nameof(Fruit), nameof(Meat), nameof(Seeds) };
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, weightIncreasePerPiece, wingSize, eatenFoods)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
