using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Paint_Lab.Interfaces;

namespace Paint_Lab.ShapesClasses
{
    public class Rectangle : IShape
    {
        public PointCollection Points { get; set; }

        public double StrokeThickness { get; set; }

        public Brush FillColorBrush { get; set; }

        public Brush StrokeColorBrush { get; set; }

        public bool Draw(Canvas canvas, Brush fillColor, Brush strokeColor, double strokeThickness,
            PointCollection points)
        {
            Point startPoint = points[0];
            Point endPoints = points[^1];
            System.Windows.Shapes.Rectangle rectangle = new System.Windows.Shapes.Rectangle
            {
                Width = endPoints.X >= startPoint.X ? (endPoints.X - startPoint.X) : (startPoint.X - endPoints.X),
                Height = endPoints.Y >= startPoint.Y ? (endPoints.Y - startPoint.Y) : (startPoint.Y - endPoints.Y),
                Fill = fillColor,
                Stroke = strokeColor,
                StrokeThickness = strokeThickness,
            };

            rectangle.SetValue(Canvas.LeftProperty, endPoints.X >= startPoint.X ? startPoint.X : endPoints.X);
            rectangle.SetValue(Canvas.TopProperty, endPoints.Y >= startPoint.Y ? startPoint.Y : endPoints.Y);
            canvas.Children.Add(rectangle);

            return true;
        }
    }
}