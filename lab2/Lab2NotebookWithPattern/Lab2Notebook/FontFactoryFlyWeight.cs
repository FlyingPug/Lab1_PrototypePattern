using Lab2Notebook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab2Notebook
{
    public class FontFactoryFlyWeight : IFontFactory
    {
        private Dictionary<(int FontSize, Color FontColor, bool Bold), Font> _fonts;

        public FontFactoryFlyWeight()
        {
            _fonts = new Dictionary<(int FontSize, Color FontColor, bool Bold), Font>();
        }

        public Font GetFont(int fontSize, Color color, bool bold)
        {
            var key = (fontSize, color, bold);

            if (_fonts.TryGetValue(key, out Font existingFont))
            {
                return existingFont;
            }

            Font newFont = new Font(fontSize, color, bold);
            _fonts.Add(key, newFont);
            return newFont;
        }
    }
}
