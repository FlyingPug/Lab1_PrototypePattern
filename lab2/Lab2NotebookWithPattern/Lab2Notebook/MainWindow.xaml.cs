using Lab2Notebook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Lab2Notebook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Text text;

        public Color MyColor { get; set; }

        public MainWindow()
        {
            text = new Text();
            InitializeComponent();

            for (int i = 0; i < 100000; i++)
            {
                Character character = text.AddCharacter("a", 0, 0, MyColor, myUpDownControl.Value ?? 12, IsBoldCheckBox.IsChecked ?? false);
                UpdateCanvas(character);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Regex CharacterSymbol = new Regex("^[a-zA-Z]$");

            Point p = Mouse.GetPosition(TextCanvas);

            if (CharacterSymbol.IsMatch(e.Key.ToString()))
            {
                Character character = text.AddCharacter(e.Key.ToString(), p.X, p.Y, MyColor, myUpDownControl.Value ?? 12, IsBoldCheckBox.IsChecked ?? false);
                UpdateCanvas(character);
            }
        }

        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void UpdateCanvas(Character character)
        {
            TextBlock textBlock = new TextBlock
            {
                Text = character.character,
                FontSize = character.Font.FontSize,
                FontWeight = character.Font.Bold ? FontWeights.Bold : FontWeights.Normal,
                Foreground = new SolidColorBrush(character.Font.FontColor),
            };

            Canvas.SetLeft(textBlock, character.x);
            Canvas.SetTop(textBlock, character.y);

            TextCanvas.Children.Add(textBlock);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (e.NewValue.HasValue)
            {
                MyColor = e.NewValue.Value;
            }
        }
    }
}
