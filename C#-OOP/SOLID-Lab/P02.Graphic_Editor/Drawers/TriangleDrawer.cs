using P02.Graphic_Editor.Contracts;
using P02.Graphic_Editor.Shapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor.Drawers
{
    public class TriangleDrawer : IDrawer
    {
        public void Draw()
        {
            Console.WriteLine("I am a triangle");
        }

        public bool IsMatch(IShape shape)
        {
            return shape is Triangle;
            
        }
    }
}
