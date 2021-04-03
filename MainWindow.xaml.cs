using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Paint_Lab.Interfaces;

namespace Paint_Lab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PointCollection _coordinates = new PointCollection(1000);
        private IShape _currentShape;
        private int _angleValue;

        private void Slider_ValueChanged_Fill(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double R = RedSliderFill.Value;
            double G = GreenSliderFill.Value;
            double B = BlueSliderFill.Value;
            var brushColor = new SolidColorBrush(Color.FromArgb(255, (byte) R, (byte) G, (byte) B));
            ColorPickerFill.Background = brushColor;
            ThicknessLine.Stroke = brushColor;
        }

        private void Slider_ValueChanged_Border(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double R = RedSliderBorder.Value;
            double G = GreenSliderBorder.Value;
            double B = BlueSliderBorder.Value;
            var brushColor = new SolidColorBrush(Color.FromArgb(255, (byte) R, (byte) G, (byte) B));
            ColorPickerBorder.Background = brushColor;
        }

        private void ThicknessSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ThicknessLine.StrokeThickness = ThicknessSlider.Value;
        }

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            CanvasWindow.Children.Clear();
        }
        
        private void CanvasWindow_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_currentShape != null)
            {
                _coordinates.Add(e.GetPosition(CanvasWindow));
            }
        }

        private void CanvasWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _coordinates.Clear();
            _coordinates.Add(e.GetPosition(CanvasWindow));
        }

        private void CanvasWindow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _currentShape?.Draw(CanvasWindow, ColorPickerFill.Background, ColorPickerBorder.Background, ThicknessSlider.Value, _coordinates);
        }

        private void LineButton_Checked(object sender, RoutedEventArgs e)
        {
            _currentShape = new ShapesClasses.Line();
        }

        private void EllipseButton_Checked(object sender, RoutedEventArgs e)
        {
            _currentShape = new ShapesClasses.Ellipse();
        }

        private void PolygonButton_Checked(object sender, RoutedEventArgs e)
        {
            _currentShape = new ShapesClasses.Polygon
            {
                Height = _angleValue
            };
        }

        private void RectangleButton_Checked(object sender, RoutedEventArgs e)
        {
            _currentShape = new ShapesClasses.Rectangle();
        }

        private void UndoButton_OnClick(object sender, RoutedEventArgs e)
        {
            int count = CanvasWindow.Children.Count;
            if (count > 0)
            {
                CanvasWindow.Children.RemoveAt(count - 1);
            }
        }

        private void AngleSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _angleValue = (int)AngleSlider.Value;
        }
    }
}