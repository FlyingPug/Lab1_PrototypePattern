using System.Windows;

namespace Lab2Notebook.Model
{
    public class Character
    {
        public Font Font { get; set; }
        public readonly string character;
        public readonly double x;
        public readonly double y;

        public Character(string character, double x, double y)
        {
            this.character = character;
            this.x = x;
            this.y = y;

            Font = new Font();
        }
    }
}