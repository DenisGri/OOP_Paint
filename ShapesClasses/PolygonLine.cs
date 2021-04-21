using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Paint_Lab.Interfaces;

namespace Paint_Lab.ShapesClasses
{
    public class PolygonLine : IShape
    {
        public PointCollection Points { get; set; }

        public double StrokeThickness { get; set; }

        public Brush FillColorBrush { get; set; }

        public Brush StrokeColorBrush { get; set; }

        public bool Draw(Canvas canvas, Brush fillColor, Brush strokeColor, double strokeThickness, PointCollection points)
        {
            var polyline = new System.Windows.Shapes.Polyline()
            {
                Points = points,
                VerticalAlignment = VerticalAlignment.Center,
                Stroke = strokeColor,
                StrokeThickness = strokeThickness,
            };
            canvas.Children.Add(polyline);

            return false;
        }
    }
}