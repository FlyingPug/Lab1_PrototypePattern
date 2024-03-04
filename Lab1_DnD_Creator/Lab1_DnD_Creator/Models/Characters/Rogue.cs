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
    }
}
