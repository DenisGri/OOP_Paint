using System;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media;

namespace Paint_Lab.Interfaces
{
    public interface IShape
    {
        private int Height { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        private PointCollection Points { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        private int Width { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        private int StrokeThickness  { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        private SolidColorBrush FillColorBrush { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        private SolidColorBrush StrokeColorBrush  { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        void Draw(Canvas canvas, Brush fillColor, Brush strokeColor, double strokeThickness);
    }
}