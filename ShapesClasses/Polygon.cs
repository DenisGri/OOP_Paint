using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Paint_Lab.ShapesClasses
{
    public class Polygon : Shape
    {
        public PointCollection Points { get; set; }

        public double StrokeThickness { get; set; }

        public Brush FillColorBrush { get; set; }

        public Brush StrokeColorBrush { get; set; }

        public override bool Draw(Canvas canvas, Brush fillColor, Brush strokeColor, double strokeThickness,
            PointCollection points)
        {
            var polygon = new System.Windows.Shapes.Polygon()
            {
                Points = points,
                Fill = fillColor,
                VerticalAlignment = VerticalAlignment.Center,
                Stroke = strokeColor,
                StrokeThickness = strokeThickness,
            };
            canvas.Children.Add(polygon);

            return false;
        }
    }
}