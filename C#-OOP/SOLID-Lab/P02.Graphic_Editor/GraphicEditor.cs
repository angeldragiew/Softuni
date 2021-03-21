using P02.Graphic_Editor.Contracts;
using P02.Graphic_Editor.Drawers;
using P02.Graphic_Editor.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace P02.Graphic_Editor
{
    public class GraphicEditor
    {
        List<IDrawer> drawers;

        public GraphicEditor()
        {
            drawers = new List<IDrawer>();
            var types = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(IDrawer).IsAssignableFrom(t) &&
                typeof(IDrawer) != t)
                .ToList();

            foreach (var type in types)
            {
                drawers.Add((IDrawer)Activator.CreateInstance(type));
            }
        }
        public void DrawShape(IShape shape)
        {
            IDrawer drawer = drawers.FirstOrDefault(s => s.IsMatch(shape));

            if (drawer == null)
            {
                Console.WriteLine($"There is no shape \"{shape.GetType().Name}\"");
            }
            else
            {
                drawer.Draw();
            }
        }
    }
}
