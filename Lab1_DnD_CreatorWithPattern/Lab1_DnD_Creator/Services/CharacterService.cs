using Lab1_DnD_Creator.Core;
using Lab1_DnD_Creator.Models;
using Lab1_DnD_Creator.Models.Characters;

namespace Lab1_DnD_Creator.Services
{
    public class CharacterService : ICharacterService
    {
        private Dictionary<string, Character> _characters = new Dictionary<string, Character>();

        public CharacterService()
        {
            _characters = new Dictionary<string, Character>();

            InitializeCharacters();
        }

        public Character GetCharacterByClassName(string className)
        {
            if (_characters.TryGetValue(className, out var characterPrototype))
            {
                var characterCopy = characterPrototype.Clone();
                return (Character)characterCopy;
            }

            throw new ArgumentException($"Unknown character class: {className}");
        }

        private async void InitializeCharacters()
        {
            _characters["Paladin"] = new Paladin();
            _characters["Rogue"] = new Rogue();
            _characters["Mage"] = new Mage();
            _characters["Barbarian"] = new Barbarian();
            var necromancer = new Mage();
            necromancer.CharClass = CharacterClass.Necromancer;
            _characters["Necromancer"] = necromancer;
            
            foreach(var character in _characters.Values)
            {
                for (int i = 0; i < Rolls.d20(); i++)
                {
                    character.LvlUp();
                }

                character.Name = (await CharacterGenerator.GetCharacterNamesAsync()).Names[0];
            }
        }
    }
}
