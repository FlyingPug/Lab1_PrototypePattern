using Lab1_DnD_Creator.Core;
using System.Reflection.PortableExecutable;

namespace Lab1_DnD_Creator.Models.Characters
{
    // помимо классов, есть большое количество подклассов, нужно предусмотреть возможность
    // добавления множества классов
    public class Mage : Character
    {
        public Mage()
        {
            CharClass = CharacterClass.Mage;
            CharIdeology = Ideology.neutral;
            Hp = 6 + Characteristics.GetCharacteristic(Characteristic.constitution);
        }

        public override void LvlUp()
        {
            Lvl++;
            Hp += Rolls.d6();
        }
    }
}
