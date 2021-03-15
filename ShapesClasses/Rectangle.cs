using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Paint_Lab.Interfaces;

namespace Paint_Lab.ShapesClasses
{
    public class Rectangle : IShape
    {
        public int Height { private get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public PointCollection Points { private get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Width { private get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int StrokeThickness { private get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public SolidColorBrush FillColorBrush { private get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public SolidColorBrush StrokeColorBrush { private get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public void Draw(Canvas canvas, Brush fillColor, Brush strokeColor, double strokeThickness)
        {
            System.Windows.Shapes.Rectangle rectangle = new  System.Windows.Shapes.Rectangle
            {
                Width = 200,
                Height = 100,
                VerticalAlignment = VerticalAlignment.Center,
                Fill = fillColor,
                Stroke = strokeColor,
                StrokeThickness = strokeThickness,
            };
            canvas.Children.Add(rectangle);
        }
    }
}