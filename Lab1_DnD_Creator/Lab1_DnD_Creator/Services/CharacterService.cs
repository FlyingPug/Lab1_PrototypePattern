using Lab1_DnD_Creator.Models;
using Lab1_DnD_Creator.Models.Characters;

namespace Lab1_DnD_Creator.Services
{
    public class CharacterService : ICharacterService
    {
        public async Task<Character> GetCharacterByClassName(string className)
        {
            Character character;
            switch(className)
            {
                case "mage":
                    character = new Mage();
                break;
                case "necromancer":
                    character = new Necromancer();
                break;
                case "paladin":
                    character = new Paladin();
                break;
                case "rogue":
                    character = new Rogue();
                break;
                default:
                    character = new Barbarian();
                break;
            }
            character.Name = (await CharacterGenerator.GetCharacterNamesAsync()).Names[0];
            character.Description = "desc";//await CharacterGenerator.GenerateCharacterStory(character);
            return character;
        }
    }
}
