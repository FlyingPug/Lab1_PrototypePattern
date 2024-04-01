using ImageViewer.Core;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace ImageViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ImageViewerController _imageViewer;

        public MainWindow()
        {
            InitializeComponent();
            _imageViewer = new ImageViewerController();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = ListOfImages.SelectedIndex;
            setImage(_imageViewer.getImage(selected));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void setImage(BitmapImage? image)
        {
            if (image == null) return;
            ImageControl.Source = image;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                Title = "Выберите папку"
            };

            var result = dialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok)
            {
                string selectedFolderPath = dialog.FileName;

                var imageFiles = Directory.GetFiles(selectedFolderPath)
                    .Where(file => file.EndsWith(".jpg") || file.EndsWith(".png") || file.EndsWith(".bmp"));

                foreach (var image in imageFiles)
                {
                    ListOfImages.Items.Add(System.IO.Path.GetFileName(image));
                }

                _imageViewer.LoadImages(selectedFolderPath);
            }
        }

        private void rightButton_Click(object sender, RoutedEventArgs e)
        {
            setImage(_imageViewer.getNextImage());
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            setImage(_imageViewer.getPreviousImage());
        }
    }
}
