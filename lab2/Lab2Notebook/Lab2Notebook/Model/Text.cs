using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Notebook.Model
{
    internal class Text
    {
        public List<Character> Characters { get; private set; }

        public Text()
        {
            Characters = new List<Character>();
        }

        public Character AddCharacter(string symbol, double x, double y)
        {
            Character character = new Character(symbol, x, y);
            Characters.Add(character);
            return character;
        }
    }
}
