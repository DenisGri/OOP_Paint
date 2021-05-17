using System.Windows.Controls;
using System.Windows.Media;
using Paint_Lab.Interfaces;

namespace Paint_Lab.ShapesClasses
{
    public abstract class Shape : IShape
    {
        protected internal PointCollection Points { get; set; }

        protected internal double StrokeThickness { get; set; }

        protected internal Brush FillColorBrush { get; set; }

        protected internal Brush StrokeColorBrush { get; set; }

        public abstract bool Draw(Canvas canvas, Brush fillColor, Brush strokeColor, double strokeThickness,
            PointCollection points);
    }
}
