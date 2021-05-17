using System.Windows.Controls;
using System.Windows.Media;

namespace Paint_Lab.Interfaces
{
    public interface IShape
    {
         bool Draw(Canvas canvas, Brush fillColor, Brush strokeColor, double strokeThickness, PointCollection points);
    }
}