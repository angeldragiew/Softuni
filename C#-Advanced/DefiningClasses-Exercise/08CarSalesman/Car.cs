using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }
        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine)
        {
            Weight = weight;
            Color = color;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Model}:");
            sb.AppendLine($"  {Engine.Model}:");
            sb.AppendLine($"    Power: {Engine.Power}");
            if (Engine.Displacement != -1)
            {
                sb.AppendLine($"    Displacement: {Engine.Displacement}");
            }
            else
            {
                sb.AppendLine("   Displacement: n/a");
            }
            
            if (Engine.Efficiency != null)
            {
                sb.AppendLine($"   Efficiency: {Engine.Efficiency}");
            }
            else
            {
                sb.AppendLine($"   Efficiency: n/a");
            }

            if (Weight != -1)
            {
                sb.AppendLine($"  Weight: {Weight}");
            }
            else
            {
                sb.AppendLine("  Weight: n/a");
            }
            if (Color != null)
            {
                sb.Append($"  Color: {Color}");
            }
            else
            {
                sb.Append("  Color: n/a");
            }
            return sb.ToString();
        }
    }
}
