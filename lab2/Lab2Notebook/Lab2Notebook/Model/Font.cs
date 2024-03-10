using System.Windows.Media;

namespace Lab2Notebook.Model
{
    public class Font
    {
        public int FontSize { get; set; }
        public Color FontColor { get; set; }
        public bool Bold { get; set; }

        public Font()
        {
            FontSize = 12;
            FontColor = Color.FromRgb(0, 0, 0);
            Bold = false;
        }
    }
}