using System.Reflection.PortableExecutable;

namespace Lab1_DnD_Creator.Models.Characters
{
    public abstract class Character : ICloneable
    {
        public string Name { get; set; }
        public Race Race { get; set; }
        public CharacterClass CharClass { get; set; }
        public Ideology CharIdeology { get; set; }
        public string Description { get; set; }
        public int Lvl { get; set; }
        public int Hp { get; set; }
        public int Defence { get; set; }
        public CharacteristicSet Characteristics { get; set; }
        public List<Skill> Skills { get; set; }

        public Character() 
        {
            Name = "???";
            Description = String.Empty;
            Lvl = 1;
            Characteristics = CharacteristicSet.GenerateChars();
            Skills = new List<Skill>();
            Race = CharacterGenerator.GetRandomEnumValue<Race>();
            Hp = 1;
            Defence = 10 + Characteristics.GetCharacteristic(Characteristic.agility);
        }

        public abstract void LvlUp();

        public void addSkill(Skill skill)
        {
            Skills.Add(skill);
        }

        public virtual object Clone()
        {
            var clone = (Character)MemberwiseClone();
            clone.Skills = new List<Skill>(Skills);
            clone.Characteristics = (CharacteristicSet)Characteristics.Clone();
            return clone;
        }
    }
}
