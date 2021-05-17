using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Paint_Lab.ShapesClasses
{
    public class Ellipse : Shape
    {

        public override bool Draw(Canvas canvas, Brush fillColor, Brush strokeColor, double strokeThickness,
            PointCollection points)
        {
            Point startPoint = points[0];
            Point endPoints = points[^1];
            System.Windows.Shapes.Ellipse ellipse = new System.Windows.Shapes.Ellipse
            {
                Width = endPoints.X >= startPoint.X ? (endPoints.X - startPoint.X) : (startPoint.X - endPoints.X),
                Height = endPoints.Y >= startPoint.Y ? (endPoints.Y - startPoint.Y) : (startPoint.Y - endPoints.Y),
                Fill = fillColor,
                Stroke = strokeColor,
                StrokeThickness = strokeThickness,
            };
            ellipse.SetValue(Canvas.LeftProperty, endPoints.X >= startPoint.X ? startPoint.X : endPoints.X);
            ellipse.SetValue(Canvas.TopProperty, endPoints.Y >= startPoint.Y ? startPoint.Y : endPoints.Y);
            canvas.Children.Add(ellipse);

            return true;
        }
    }
}