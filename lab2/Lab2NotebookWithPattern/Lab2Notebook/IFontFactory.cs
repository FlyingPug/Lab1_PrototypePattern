using Lab2Notebook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab2Notebook
{
    public interface IFontFactory
    {
        public Font GetFont(int fontSize, Color color, bool bold);
    }
}
