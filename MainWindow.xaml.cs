using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using BaseClassesPlugin;
using Microsoft.Win32;
using Newtonsoft.Json;
using Paint_Lab.Control;
using Paint_Lab.ShapesClasses;

namespace Paint_Lab
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly PointCollection _coordinates = new(1000);
        private readonly Undo _listShape;
        private readonly Redo _stackShape;
        private int _coordinatesItr;
        private Shape _currentShape;
        private string _filePath;

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
            if (_currentShape != null)
            {
                _coordinates.Add(e.GetPosition(CanvasWindow));
                _stackShape.Push(_currentShape);
            }
        }

        private void SerializeShapes(string folder)
        {
            var jsonString = JsonConvert.SerializeObject(_stackShape.FillList(), new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
            File.WriteAllText(folder, jsonString);
        }

        private void DeSerializeShapes(string filename)
        {
            try
            {
                var jsonString = File.ReadAllText(filename);
                var shapesObjects = JsonConvert.DeserializeObject<List<Shape>>(jsonString, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });
                var shapes = new List<Shape>();
                for (var i = 0; i < shapesObjects?.Count; i++)
                {
                    var tempShape = shapesObjects[i];
                    shapes.Add(tempShape);
                }

                for (var i = 0; i < shapes?.Count; i++)
                {
                    _stackShape.Push(shapes[i]);
                    _listShape.Add(shapes[i]);
                }

                _listShape.Drawing(CanvasWindow);
            }
            catch (Exception e)
            {
                MessageBox.Show("Невозможно прочитать сожержимое файла:\n Файл поврежден!", "Alert",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void CanvasWindow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_currentShape != null)
            {
                _coordinates.Add(e.GetPosition(CanvasWindow));
                var newCollection = new PointCollection(_coordinates.Count - _coordinatesItr);
                for (var i = _coordinatesItr; i < _coordinates.Count; i++) newCollection.Add(_coordinates[i]);

                _currentShape.Points = newCollection;
                _currentShape.FillColorBrush = ColorPickerFill.Background;
                _currentShape.StrokeColorBrush = ColorPickerBorder.Background;
                _currentShape.StrokeThickness = ThicknessSlider.Value;
                _listShape.Add(_currentShape);

                var isRightClick = _currentShape?.Draw(CanvasWindow, ColorPickerFill.Background,
                    ColorPickerBorder.Background, ThicknessSlider.Value, newCollection);

                if ((bool) isRightClick) CanvasWindow_MouseRightButtonDown(sender, e);
            }
        }

        private void CanvasWindow_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            _currentShape = null;
            NullButton.IsChecked = true;
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
                var count = CanvasWindow.Children.Count;
                if (count > 0) CanvasWindow.Children.RemoveAt(count - 1);
            }
        }

        private void RedoButton_OnClickRedoButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_stackShape.IsEmpty())
            {
                _listShape.Add(_stackShape.Pop());
                var toDraw = _listShape.Last();
                toDraw.Draw(CanvasWindow, toDraw.FillColorBrush, toDraw.StrokeColorBrush, toDraw.StrokeThickness,
                    toDraw.Points);
            }
        }

        private bool SaveFileDialog()
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Json documents (.json)|*.json",
                AddExtension = true,
                DefaultExt = ".json",
                CreatePrompt = true,
                OverwritePrompt = true
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                _filePath = saveFileDialog.FileName;
                return true;
            }

            return false;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog();

            SerializeShapes(_filePath);
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDlg = new OpenFileDialog
            {
                Multiselect = false, DefaultExt = ".json", Filter = "Json documents (.json)|*.json"
            };

            var result = openFileDlg.ShowDialog();
            if (result != true) return;
            Test.Content = openFileDlg.FileName;
            var fileName = openFileDlg.FileName;

            DeSerializeShapes(fileName);
        }
    }
}