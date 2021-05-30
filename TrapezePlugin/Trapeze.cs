using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using BaseClassesPlugin;

namespace TrapezePlugin
{
    public class Trapeze : Shape

    {
        public override bool Draw(Canvas canvas, Brush fillColor, Brush strokeColor, double strokeThickness, PointCollection points)
        {
            var trapezoidPoints = new PointCollection(4);
            Point p1, p2, p3, p4;
            p1.X = points[0].X;
            p1.Y = points[1].Y;
            trapezoidPoints.Add(p1);
            p2.X = points[0].X + (points[1].X - points[0].X) / 3;
            p2.Y = points[0].Y;
            trapezoidPoints.Add(p2);
            p3.X = points[0].X + (points[1].X - points[0].X) / 3 * 2;
            p3.Y = points[0].Y;
            trapezoidPoints.Add(p3);
            p4.X = points[1].X;
            p4.Y = points[1].Y;
            trapezoidPoints.Add(p4);

            var polygon = new System.Windows.Shapes.Polygon
            {
                Points = trapezoidPoints,
                Fill = fillColor,
                VerticalAlignment = VerticalAlignment.Center,
                Stroke = strokeColor,
                StrokeThickness = strokeThickness
            };
            canvas.Children.Add(polygon);

            return true;
        }
    }
}
