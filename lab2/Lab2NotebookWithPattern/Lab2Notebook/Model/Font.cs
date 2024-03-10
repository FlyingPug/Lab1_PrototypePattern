using System.Collections;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab2Notebook.Model
{
    public sealed class Font
    {
        public int FontSize { get; set; }
        public Color FontColor { get; set; }
        public bool Bold { get; set; }

        public Font(int fontSize, Color color, bool bold)
        {
            FontSize = fontSize;
            FontColor = color;
            Bold = bold;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            Font other = (Font)obj;
            return EqualityComparer<int>.Default.Equals(FontSize, other.FontSize)
                && FontColor.Equals(other.FontColor)
                && Bold == other.Bold;
        }

        public override int GetHashCode()
        {
            return FontColor.GetHashCode();
        }
    }
}