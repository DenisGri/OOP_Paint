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
        public int Height { get; set; }
        public PointCollection Points { get; set; }
        public int Width { get; set; }
        public int StrokeThickness { get; set; }
        public Brush FillColorBrush { get; set; }
        public Brush StrokeColorBrush { get; set; }
        public void Draw(Canvas canvas, Brush fillColor, Brush strokeColor, double strokeThickness, PointCollection points)
        {
            var polyline = new System.Windows.Shapes.Polyline()
            {
                Points = points,
                VerticalAlignment = VerticalAlignment.Center,
                Stroke = strokeColor,
                StrokeThickness = strokeThickness,
            };
            canvas.Children.Add(polyline);
        }
    }
}