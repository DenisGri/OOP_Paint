using System.Windows.Controls;
using System.Windows.Media;

namespace BaseClassesPlugin
{
    public interface IShape
    {
        bool Draw(Canvas canvas, Brush fillColor, Brush strokeColor, double strokeThickness, PointCollection points);
    }
}