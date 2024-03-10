using Lab1_DnD_Creator.Core;

namespace Lab1_DnD_Creator.Models.Characters
{
    public class Paladin : Character
    {
        public Paladin()
        {
            CharClass = CharacterClass.Paladin;
            CharIdeology = Ideology.good;
            Hp = 10 + Characteristics.GetCharacteristic(Characteristic.constitution);
        }

        public override void LvlUp()
        {
            Lvl++;
            Hp += Rolls.d10();
        }
    }
}
