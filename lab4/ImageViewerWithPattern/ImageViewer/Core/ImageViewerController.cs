using ImageViewer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ImageViewer.Core
{
    internal class ImageViewerController
    {
        private List<ImageModel> _imageModels;
        private int _currentIndex = 0;

        public ImageViewerController()
        {
            _imageModels = new List<ImageModel>();
        }

        public void LoadImages(string path)
        {
            _imageModels.Clear();

            var imageFiles = Directory.GetFiles(path)
    .Where(file => file.EndsWith(".jpg") || file.EndsWith(".png") || file.EndsWith(".bmp"));

            foreach (var image in imageFiles)
            {
                _imageModels.Add(new ImageModel(image));
            }
        }

        public BitmapImage? getImage(int index)
        {
            if (index < 0 || index >= _imageModels.Count) return null;
            return _imageModels[index].Image;
        }

        public BitmapImage? getNextImage()
        {
            _currentIndex++;
            return getImage(_currentIndex);
        }

        public BitmapImage? getPreviousImage()
        {
            _currentIndex--;
            return getImage(_currentIndex);
        }
    }
}
