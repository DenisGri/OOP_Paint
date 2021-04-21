using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Paint_Lab.Interfaces;

namespace Paint_Lab.ShapesClasses
{
    public class Ellipse : IShape
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