using Lab1_DnD_Creator.Core;

namespace Lab1_DnD_Creator.Models.Characters
{
    public class Rogue : Character
    {
        public Rogue()
        {
            CharClass = CharacterClass.Rogue;
            CharIdeology = Ideology.neutral;
            Hp = 8 + Characteristics.GetCharacteristic(Characteristic.constitution);
        }
        public override void LvlUp()
        {
            Lvl++;
            Hp += Rolls.d8();
        }
    }
}
