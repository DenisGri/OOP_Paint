using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace BaseClassesPlugin
{
    public abstract class Shape : IShape
    {
        protected Shape(PointCollection point, double strokeThickness, Brush fillColorBrush, Brush strokeColorBrush,
            Type shapeType)
        {
            Points = point;
            StrokeThickness = strokeThickness;
            FillColorBrush = fillColorBrush;
            StrokeColorBrush = strokeColorBrush;
        }

        protected Shape()
        {

        }

        public PointCollection Points { get; set; }

        public double StrokeThickness { get; set; }

        public Brush FillColorBrush { get; set; }

        public Brush StrokeColorBrush { get; set; }


        public abstract bool Draw(Canvas canvas, Brush fillColor, Brush strokeColor, double strokeThickness,
            PointCollection points);

    }
}