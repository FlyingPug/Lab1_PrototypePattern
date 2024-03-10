using Lab1_DnD_Creator.Models.Characters;

namespace Lab1_DnD_Creator.Services
{
    public interface ICharacterService
    {
        Task<Character> GetCharacterByClassName(string className);
    }
}
