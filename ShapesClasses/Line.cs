using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Paint_Lab.Interfaces;

namespace Paint_Lab.ShapesClasses
{
    public class Line : IShape
    {
        public PointCollection Points { get; set; }
        public double StrokeThickness { get; set; }
        public Brush FillColorBrush { get; set; }
        public Brush StrokeColorBrush { get; set; }

        public bool Draw(Canvas canvas, Brush fillColor, Brush strokeColor, double strokeThickness,
            PointCollection points)
        {
            System.Windows.Shapes.Line line = new System.Windows.Shapes.Line
            {
                X1 = points[0].X,
                Y1 = points[0].Y,
                X2 = points[^1].X,
                Y2 = points[^1].Y,
                VerticalAlignment = VerticalAlignment.Center,
                Fill = fillColor,
                Stroke = strokeColor,
                StrokeThickness = strokeThickness,
            };
            canvas.Children.Add(line);

            return true;
        }
    }
}