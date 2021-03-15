using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Paint_Lab.Interfaces;

namespace Paint_Lab.ShapesClasses
{
    public class Polygon : IShape
    {
        public int Height { private get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public PointCollection Points { private get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Width { private get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int StrokeThickness { private get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public SolidColorBrush FillColorBrush { private get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public SolidColorBrush StrokeColorBrush { private get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public void Draw(Canvas canvas, Brush fillColor, Brush strokeColor, double strokeThickness)
        {
            System.Windows.Shapes.Polygon polygon = new System.Windows.Shapes.Polygon
            {
                Width = 500,
                Height = 500,
                Points =
                    PointCollection.Parse(
                        "10,150 30,140 50,168 70,120 90,185 110,100 130,200 150,80 170,215 190,60 210,250"),
                VerticalAlignment = VerticalAlignment.Center,
                Fill = fillColor,
                Stroke = strokeColor,
                StrokeThickness = strokeThickness,
            };
            canvas.Children.Add(polygon);
        }
    }
}