using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ImageViewer.Models
{
    internal class ImageModel
    {
        public string Path { get; set; } = "";

        public BitmapImage? _image = null;

        public BitmapImage Image
        {
            get
            {
                return _image;
            }
            
            set
            {
                _image = value;
            }
        }

        public ImageModel(string path)
        {
            Path = path;
            _image = new BitmapImage(new Uri(path));
        }
    }
}
