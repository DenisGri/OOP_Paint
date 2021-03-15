using System;
using System.Drawing;
using System.Windows.Media;
using Paint_Lab.Interfaces;

namespace Paint_Lab.ShapesClasses
{
    public class Line : IShape
    {
        public int Height { private get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public PointCollection Points { private get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Width { private get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int StrokeThickness { private get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public SolidColorBrush FillColorBrush { private get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public SolidColorBrush StrokeColorBrush { private get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public void Draw()
        {
            throw new System.NotImplementedException();
        }
    }
}