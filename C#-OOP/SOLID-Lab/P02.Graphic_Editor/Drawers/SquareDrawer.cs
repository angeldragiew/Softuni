using P02.Graphic_Editor.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor.Drawers
{
    public class SquareDrawer : IDrawer
    {
        public void Draw()
        {
            Console.WriteLine("I'm Square");
        }

        public bool IsMatch(IShape shape)
        {
            return shape is Square;
        }
    }
}
