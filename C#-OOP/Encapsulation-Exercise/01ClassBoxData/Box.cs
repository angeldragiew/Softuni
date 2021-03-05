using System;
using System.Collections.Generic;
using System.Text;

namespace _01ClassBoxData
{
    public class Box
    {
        private double length;
        private double height;
        private double width;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get { return length; }
            private set
            {
                ThrowIfSideIsInvalid(value, nameof(Length));
                length = value;
            }
        }

        public double Width
        {
            get { return width; }
            private set
            {
                ThrowIfSideIsInvalid(value, nameof(Width));
                width = value;
            }
        }

        public double Height
        {
            get { return height; }
            private set
            {
                ThrowIfSideIsInvalid(value, nameof(Height));
                height = value;
            }
        }

        public double CalculateSurfaceArea()
        {
            double surfaceArea = 2 * length * width + 2 * length * height + 2 * width * height;
            return surfaceArea;
        }

        public double CalculateVolume()
        {
            double volume = length * width * height;
            return volume;
        }

        public double CalculateLateralSurfaceArea()
        {
            double lateralSurfaceArea = 2 * length * height + 2 * width * height;
            return lateralSurfaceArea;
        }

        private void ThrowIfSideIsInvalid(double size, string side)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"{side} cannot be zero or negative.");
            }
        }
    }
}
