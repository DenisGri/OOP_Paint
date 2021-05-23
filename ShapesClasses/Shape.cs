using System;
using System.Windows.Controls;
using System.Windows.Media;
using Paint_Lab.Interfaces;


namespace Paint_Lab.ShapesClasses
{
    public abstract class Shape : IShape
    {
        public PointCollection Points { get; set; }

        public  double StrokeThickness { get; set; }

        public  Brush FillColorBrush { get; set; } 

        public  Brush StrokeColorBrush { get; set; }

        public  Type ShapeType { get; set; }

        protected Shape(PointCollection point, double strokeThickness, Brush fillColorBrush, Brush strokeColorBrush, Type shapeType)
        {
            Points = point;
            StrokeThickness = strokeThickness;
            FillColorBrush = fillColorBrush;
            StrokeColorBrush = strokeColorBrush;
            ShapeType = shapeType;
        }

        protected Shape()
        {

        }

        public abstract bool Draw(Canvas canvas, Brush fillColor, Brush strokeColor, double strokeThickness,
            PointCollection points);

    }
}