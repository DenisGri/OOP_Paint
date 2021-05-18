using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using Paint_Lab.ShapesClasses;

namespace Paint_Lab.Control
{
    public class Undo
    {
        private readonly List<Shape> _shapesList;

        public void Add(Shape shape)
        {
            _shapesList.Add(shape);
        }

        public Shape Last()
        {
            var shape = _shapesList.Last();
            return shape;
        }

        public void Drawing(Canvas canvas, Brush fillColorBrush, Brush strokeColorBrush, double strokeThickness, PointCollection points)
        {
            foreach (var shape in _shapesList)
            {
                shape.Draw(canvas, fillColorBrush, strokeColorBrush, strokeThickness, points);
            }
        }

        public Undo()
        {
            _shapesList = new List<Shape>();
        }

        public Shape Remove()
        {
            Shape temp = _shapesList.Last();
            _shapesList.Remove(_shapesList.Last());
            return temp;
        }

        public bool IsEmpty()
        {
            return _shapesList.Count != 0;
        }
    }
}