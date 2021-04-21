using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Paint_Lab.Interfaces;

namespace Paint_Lab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly PointCollection _coordinates = new(1000);
        private readonly PointCollection _coordinatesPreview = new(100);
        private IShape _currentShape;
        private int _coordinatesItr;
        private readonly List<IShape> _redoShapesList = new List<IShape>();
        private int _itrUndoRedo = -1;

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

        private void CanvasWindow_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                _coordinatesPreview.Add(e.GetPosition(CanvasWindow));
            }

            _ = CleanerTask();
        }

        async Task CleanerTask()
        {
            PointCollection newCollection = new PointCollection(2) {_coordinatesPreview[0], _coordinatesPreview[^1]};
            _currentShape?.Draw(CanvasWindow, ColorPickerFill.Background, ColorPickerBorder.Background,
                ThicknessSlider.Value, newCollection);
            await Task.Delay(1);
            int count = CanvasWindow.Children.Count;
            if (count > 0)
            {
                CanvasWindow.Children.RemoveAt(count - 1);
            }

            await Task.CompletedTask;
        }

        private void CanvasWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _coordinates.Add(e.GetPosition(CanvasWindow));
            _coordinatesPreview.Add(e.GetPosition(CanvasWindow));
        }

        private void CanvasWindow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _coordinates.Add(e.GetPosition(CanvasWindow));
            PointCollection newCollection = new PointCollection(_coordinates.Count - _coordinatesItr);
            for (int i = _coordinatesItr; i < _coordinates.Count; i++)
            {
                newCollection.Add(_coordinates[i]);
            }

            var isRightClick = _currentShape?.Draw(CanvasWindow, ColorPickerFill.Background,
                ColorPickerBorder.Background, ThicknessSlider.Value, newCollection);

            if (_currentShape != null)
            {
                _currentShape.Points = newCollection;
                _currentShape.FillColorBrush = ColorPickerFill.Background;
                _currentShape.StrokeColorBrush = ColorPickerBorder.Background;
                _currentShape.StrokeThickness = ThicknessSlider.Value;
            }

            _redoShapesList.Add(_currentShape);
            _itrUndoRedo++;


            Test.Content = $"{_itrUndoRedo.ToString()} _ {CanvasWindow.Children.Count.ToString()}";


            if (isRightClick != null && (bool) isRightClick)
            {
                CanvasWindow_MouseRightButtonDown(sender, e);
            }

            _coordinatesPreview.Clear();
        }

        private void CanvasWindow_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            _coordinatesItr = _coordinates.Count;
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
            _currentShape = new ShapesClasses.Polygon();
        }

        private void RectangleButton_Checked(object sender, RoutedEventArgs e)
        {
            _currentShape = new ShapesClasses.Rectangle();
        }

        private void PolylineButton_Checked(object sender, RoutedEventArgs e)
        {
            _currentShape = new ShapesClasses.PolygonLine();
        }

        private void UndoButton_OnClick(object sender, RoutedEventArgs e)
        {
            int count = CanvasWindow.Children.Count;
            if (count > 0)
            {
                CanvasWindow.Children.RemoveAt(count - 1);
                _itrUndoRedo--;
            }

            Test.Content = $"{_itrUndoRedo.ToString()} _ {CanvasWindow.Children.Count.ToString()}";
        }

        private void RedoButton_OnClickRedoButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_itrUndoRedo > -1 && _itrUndoRedo < CanvasWindow.Children.Count)
            {
                var toDraw = _redoShapesList[_itrUndoRedo];
                toDraw.Draw(CanvasWindow, toDraw.FillColorBrush, toDraw.StrokeColorBrush, toDraw.StrokeThickness,
                    toDraw.Points);
                _itrUndoRedo++;
            }

            if (_itrUndoRedo == -1)
            {
                var toDraw = _redoShapesList[^1];
                toDraw.Draw(CanvasWindow, toDraw.FillColorBrush, toDraw.StrokeColorBrush, toDraw.StrokeThickness,
                    toDraw.Points);
                _itrUndoRedo++;
            }

            Test.Content = $"{_itrUndoRedo.ToString()} _ {CanvasWindow.Children.Count.ToString()}";
        }
    }
}