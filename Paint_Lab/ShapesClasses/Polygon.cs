using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using BaseClassesPlugin;

namespace Paint_Lab.ShapesClasses
{
    public class Polygon : Shape
    {
        public override bool Draw(Canvas canvas, Brush fillColor, Brush strokeColor, double strokeThickness,
            PointCollection points)
        {
            var polygon = new System.Windows.Shapes.Polygon
            {
                Points = points,
                Fill = fillColor,
                VerticalAlignment = VerticalAlignment.Center,
                Stroke = strokeColor,
                StrokeThickness = strokeThickness
            };
            canvas.Children.Add(polygon);

            return false;
        }
    }
}