using Lab1_DnD_Creator.Core;

namespace Lab1_DnD_Creator.Models.Characters
{
    public class Barbarian : Character
    {
        public Barbarian()
        {
            CharClass = CharacterClass.Barbarian;
            CharIdeology = Ideology.neutral;
            Hp = 12 + Characteristics.GetCharacteristic(Characteristic.constitution);
            Defence = 10 
                + Characteristics.GetCharacteristic(Characteristic.constitution)
                + Characteristics.GetCharacteristic(Characteristic.agility);
        }

        public override void LvlUp()
        {
            Lvl++;
            Hp += Rolls.d12() + Characteristics.GetCharacteristic(Characteristic.agility);
        }
    }
}
