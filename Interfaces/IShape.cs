using System;

using System.Windows.Controls;
using System.Windows.Media;

namespace Paint_Lab.Interfaces
{
    public interface IShape
    {
        public int Height{ get; set; }
        
        public int Width{ get; set; }

        public PointCollection Points{ get; set; }

        public int StrokeThickness{ get; set; }

        public Brush FillColorBrush{ get; set; }

        public Brush StrokeColorBrush{ get; set; }

        void Draw(Canvas canvas, Brush fillColor, Brush strokeColor, double strokeThickness, PointCollection points);
    }
}