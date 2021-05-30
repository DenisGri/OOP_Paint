using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using BaseClassesPlugin;
using Paint_Lab.ShapesClasses;

namespace Paint_Lab.Control
{
    public class Undo
    {
        private readonly List<Shape> _shapesList;

        public Undo()
        {
            _shapesList = new List<Shape>();
        }

        public void Add(Shape shape)
        {
            _shapesList.Add(shape);
        }

        public Shape Last()
        {
            var shape = _shapesList.Last();
            return shape;
        }

        public void Drawing(Canvas canvas)
        {
            foreach (var shape in _shapesList)
                shape.Draw(canvas, shape.FillColorBrush, shape.StrokeColorBrush, shape.StrokeThickness, shape.Points);
        }

        public Shape Remove()
        {
            var temp = _shapesList.Last();
            _shapesList.Remove(_shapesList.Last());
            return temp;
        }

        public bool IsEmpty()
        {
            return _shapesList.Count != 0;
        }
    }
}