using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Paint_Lab.ShapesClasses
{
    public class PolygonLine : Shape
    {
        public override bool Draw(Canvas canvas, Brush fillColor, Brush strokeColor, double strokeThickness,
            PointCollection points)
        {
            var polyline = new Polyline
            {
                Points = points,
                VerticalAlignment = VerticalAlignment.Center,
                Stroke = strokeColor,
                StrokeThickness = strokeThickness
            };
            canvas.Children.Add(polyline);
            return false;
        }
    }
}