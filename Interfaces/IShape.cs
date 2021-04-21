using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace Paint_Lab.Interfaces
{
    public interface IShape
    {
        public PointCollection Points { get; set; }

        public double StrokeThickness { get; set; }

        public Brush FillColorBrush { get; set; }

        public Brush StrokeColorBrush { get; set; }

        bool Draw(Canvas canvas, Brush fillColor, Brush strokeColor, double strokeThickness, PointCollection points);
    }
}