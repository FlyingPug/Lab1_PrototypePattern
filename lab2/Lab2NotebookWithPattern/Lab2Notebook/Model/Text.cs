using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab2Notebook.Model
{
    internal class Text
    {
        public List<Character> Characters { get; private set; }

        private FontFactoryFlyWeight fontFactory;

        public Text()
        {
            Characters = new List<Character>();
            fontFactory = new FontFactoryFlyWeight();
        }

        public Character AddCharacter(string symbol, double x, double y, Color color, int fontSize = 12, bool bold = true)
        {
            Font newFont = fontFactory.GetFont(fontSize, color, bold);

            Character character = new Character(symbol, x, y, newFont);
            Characters.Add(character);
            return character;
        }
    }
}
