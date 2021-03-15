using System;
using System.Drawing;
using System.Windows.Media;

namespace Paint_Lab.Interfaces
{
    public interface IShape
    {
        private int Height { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        private Point LeftTopCursor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        private Point RightBottomCursor  { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        private int Width { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        private int StrokeThickness  { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        private SolidColorBrush FillColorBrush { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        private SolidColorBrush StrokeColorBrush  { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        void Draw();
    }
}