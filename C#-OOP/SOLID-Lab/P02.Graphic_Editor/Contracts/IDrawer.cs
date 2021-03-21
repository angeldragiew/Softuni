using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor.Contracts
{
    public interface IDrawer
    {
        void Draw();

        bool IsMatch(IShape shape);
    }
}
