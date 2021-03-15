using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Paint_Lab.Interfaces;
using Paint_Lab.ShapesClasses;

namespace Paint_Lab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
            if (LineButton.IsChecked != null && (bool) LineButton.IsChecked)
            {
                IShape shape = new ShapesClasses.Line();
                shape.Draw(CanvasWindow,ColorPickerFill.Background, ColorPickerBorder.Background, ThicknessSlider.Value);
            }

            if (EllipseButton.IsChecked != null && (bool) EllipseButton.IsChecked)
            {
                IShape shape = new ShapesClasses.Ellipse();
                shape.Draw(CanvasWindow,ColorPickerFill.Background, ColorPickerBorder.Background, ThicknessSlider.Value);
            }

            if (RectangleButton.IsChecked != null && (bool) RectangleButton.IsChecked)
            {
                IShape shape = new ShapesClasses.Rectangle();
                shape.Draw(CanvasWindow,ColorPickerFill.Background, ColorPickerBorder.Background, ThicknessSlider.Value);
            }

            if (PolygonButton.IsChecked != null && (bool) PolygonButton.IsChecked)
            {
                IShape shape = new ShapesClasses.Polygon();
                shape.Draw(CanvasWindow,ColorPickerFill.Background, ColorPickerBorder.Background, ThicknessSlider.Value);
            }
        }
    }
}