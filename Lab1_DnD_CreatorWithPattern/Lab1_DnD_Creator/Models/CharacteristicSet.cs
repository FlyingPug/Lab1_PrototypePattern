using Lab1_DnD_Creator.Core;
using Lab1_DnD_Creator.Models.Characters;
using System.Reflection.PortableExecutable;

namespace Lab1_DnD_Creator.Models
{
    public struct CharacteristicSet : ICloneable
    {
        public Dictionary<Characteristic, int> chars;

        public CharacteristicSet()
        {
            chars = new Dictionary<Characteristic, int>();
            chars.Add(Characteristic.strength, 0);
            chars.Add(Characteristic.constitution, 0);
            chars.Add(Characteristic.intelligence, 0);
            chars.Add(Characteristic.wisdom, 0);
            chars.Add(Characteristic.agility, 0);
            chars.Add(Characteristic.charisma, 0);
        }

        public int GetModificator(Characteristic charName)
        {
            if (!chars.ContainsKey(charName)) return 0;
            
            int c = chars[charName];

            return (c - 10) / 2;
        }

        public int GetCharacteristic(Characteristic charName)
        {
            if (!chars.ContainsKey(charName)) return 0;

            return chars[charName];
        }

        public static CharacteristicSet GenerateChars()
        {
            CharacteristicSet charsS = new CharacteristicSet();

            charsS.chars = charsS.chars.ToDictionary(
                 kvp => kvp.Key,
                 kvp => GenerateChar()
             );

            return charsS;
        }

        private static int GenerateChar()
        {
            List<int> rolls = new List<int>();

            for(int i = 0; i < 4; i++)
            {
                rolls.Add(Rolls.d6());
            }

            return rolls.Sum() - rolls.Min();
        }

        public object Clone()
        {
            var clone = (CharacteristicSet)MemberwiseClone();
            clone.chars = new Dictionary<Characteristic, int>(chars);
            return clone;
        }
    }
}