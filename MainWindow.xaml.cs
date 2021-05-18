using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Paint_Lab.Control;
using Paint_Lab.ShapesClasses;

namespace Paint_Lab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly PointCollection _coordinates = new(1000);
        private Shape _currentShape;
        private int _coordinatesItr;
        private readonly Undo _listShape;
        private readonly Redo _stackShape;

        public MainWindow()
        {
            _listShape = new Undo();
            _stackShape = new Redo();
        }

        private void Slider_ValueChanged_Fill(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var r = RedSliderFill.Value;
            var g = GreenSliderFill.Value;
            var b = BlueSliderFill.Value;
            var brushColor = new SolidColorBrush(Color.FromArgb(255, (byte) r, (byte) g, (byte) b));
            ColorPickerFill.Background = brushColor;
            ThicknessLine.Stroke = brushColor;
        }

        private void Slider_ValueChanged_Border(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var r = RedSliderBorder.Value;
            var g = GreenSliderBorder.Value;
            var b = BlueSliderBorder.Value;
            var brushColor = new SolidColorBrush(Color.FromArgb(255, (byte) r, (byte) g, (byte) b));
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
        
        private void CanvasWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _coordinates.Add(e.GetPosition(CanvasWindow));
            _stackShape.Push(_currentShape);
        }

        private void CanvasWindow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _coordinates.Add(e.GetPosition(CanvasWindow));
            PointCollection newCollection = new PointCollection(_coordinates.Count - _coordinatesItr);
            for (int i = _coordinatesItr; i < _coordinates.Count; i++)
            {
                newCollection.Add(_coordinates[i]);
            }

           
            if (_currentShape != null)
            {
                _currentShape.Points = newCollection;
                _currentShape.FillColorBrush = ColorPickerFill.Background;
                _currentShape.StrokeColorBrush = ColorPickerBorder.Background;
                _currentShape.StrokeThickness = ThicknessSlider.Value;
                _listShape.Add(_currentShape);
            }

            var isRightClick = _currentShape?.Draw(CanvasWindow, ColorPickerFill.Background,
                ColorPickerBorder.Background, ThicknessSlider.Value, newCollection);

            if (isRightClick != null && (bool) isRightClick)
            {
                CanvasWindow_MouseRightButtonDown(sender, e);
            }

            
            RadioButtonDisable();
        }

        private void RadioButtonDisable()
        {
            _currentShape = null;
            NullButton.IsChecked = true;
        }

        private void CanvasWindow_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            _coordinatesItr = _coordinates.Count;
        } 

        private void LineButton_Checked(object sender, RoutedEventArgs e)
        {
            _currentShape = new Line();
        }

        private void EllipseButton_Checked(object sender, RoutedEventArgs e)
        {
            _currentShape = new Ellipse();
        }

        private void PolygonButton_Checked(object sender, RoutedEventArgs e)
        {
            _currentShape = new Polygon();
        }

        private void RectangleButton_Checked(object sender, RoutedEventArgs e)
        {
            _currentShape = new Rectangle();
        }

        private void PolylineButton_Checked(object sender, RoutedEventArgs e)
        {
            _currentShape = new PolygonLine();
        }

        private void UndoButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_listShape.IsEmpty())
            {
                _stackShape.Push(_listShape.Remove());
                int count = CanvasWindow.Children.Count;
                if (count > 0)
                {
                    CanvasWindow.Children.RemoveAt(count - 1);
                }

            }
        }

        private void RedoButton_OnClickRedoButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_stackShape.IsEmpty())
            {
                _listShape.Add(_stackShape.Pop());
                Shape toDraw = _listShape.Last();
                toDraw.Draw(CanvasWindow, toDraw.FillColorBrush, toDraw.StrokeColorBrush, toDraw.StrokeThickness,
                    toDraw.Points);
            }
        }
    }
}