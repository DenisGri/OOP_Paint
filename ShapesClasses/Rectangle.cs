using System.Drawing;
using System.Windows.Media;
using Paint_Lab.Interfaces;

namespace Paint_Lab.ShapesClasses
{
    public class Rectangle : IShape
    {
        public int Height { get; set; }
        public Point LeftTopCursor { get; set; }
        public Point RightBottomCursor { get; set; }
        public int Width { get; set; }
        public int StrokeThickness { get; set; }
        public SolidColorBrush FillColorBrush { get; set; }
        public SolidColorBrush StrokeColorBrush { get; set; }
        public void Draw()
        {
            throw new System.NotImplementedException();
        }
    }
}