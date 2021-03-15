using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double h;
        private double w;

        public Rectangle(double height, double width)
        {
            h = height;
            w = width;
        }

        public override double CalculateArea()
        {
            return h * w;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (h + w);
        }

        public override string Draw()
        {
            return $"Drawing {nameof(Rectangle)}";
        }
    }
}
