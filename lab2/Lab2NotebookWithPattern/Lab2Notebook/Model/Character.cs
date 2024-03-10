using System.Windows;
using System.Windows.Media;

namespace Lab2Notebook.Model
{
    public class Character
    {
        public Font Font { get; set; }
        public readonly string character;
        public readonly double x;
        public readonly double y;

        public Character(string character, double x, double y, Font font)
        {
            this.character = character;
            this.x = x;
            this.y = y;
            Font = font;
        }
    }
}