using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Paint_Lab.Interfaces;

namespace Paint_Lab.ShapesClasses
{
    public class Polygon : IShape
    {
        public int Height { get; set; }
        public PointCollection Points { get; set; }
        public int Width { get; set; }
        public int StrokeThickness { get; set; }
        public Brush FillColorBrush { get; set; }
        public Brush StrokeColorBrush { get; set; }
        public int AngleCounter { get; set; }

        public void Draw(Canvas canvas, Brush fillColor, Brush strokeColor, double strokeThickness,
            PointCollection points)
        {
            Point startPoint = points[0];
            Point endPoints = points[^1];
            AngleCounter = Height;
            System.Windows.Shapes.Polygon polygon = new System.Windows.Shapes.Polygon
            {
                Width = endPoints.X >= startPoint.X ? (endPoints.X - startPoint.X) : (startPoint.X - endPoints.X),
                Height = endPoints.Y >= startPoint.Y ? (endPoints.Y - startPoint.Y) : (startPoint.Y - endPoints.Y),
                Fill = fillColor,
                Stroke = strokeColor,
                StrokeThickness = strokeThickness,
            };
            double radius = ((polygon.Width / 2) + (polygon.Height / 2)) / 2;
            double angle = 2 * Math.PI / AngleCounter;
            PointCollection polygonPointCollection = new PointCollection(AngleCounter);

            for (int i = 0; i < AngleCounter; i++)
            {
                Point temPoint;
                temPoint.X = polygon.Width / 2 + radius * Math.Cos(angle * i);
                temPoint.Y = polygon.Height / 2 + radius * Math.Sin(angle * i);
                polygonPointCollection.Add(temPoint);
            }

            polygon.Points = polygonPointCollection;
            polygon.SetValue(Canvas.LeftProperty, endPoints.X >= startPoint.X ? startPoint.X : endPoints.X);
            polygon.SetValue(Canvas.TopProperty, endPoints.Y >= startPoint.Y ? startPoint.Y : endPoints.Y);
            canvas.Children.Add(polygon);
        }
    }
}