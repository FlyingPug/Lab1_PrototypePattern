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
                if (_image == null) return new BitmapImage(new Uri(Path));
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
        }
    }
}
