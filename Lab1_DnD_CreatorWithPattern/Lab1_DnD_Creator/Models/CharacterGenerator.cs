using Lab1_DnD_Creator.Models.Characters;
using Lab1_DnD_Creator.wwwroot.client;

namespace Lab1_DnD_Creator.Models
{
    public class CharacterGenerator
    {
        static HttpClient client = new HttpClient();

        //https://muna.ironarachne.com/dwarf/?count=1&nameType=male
        public static async Task<CharacterNames> GetCharacterNamesAsync(string path = "https://muna.ironarachne.com/dwarf/?count=1&nameType=male")
        {
            CharacterNames character = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                character = await response.Content.ReadFromJsonAsync<CharacterNames>();
            }
            return character;
        }

        public static async Task<string> GenerateCharacterStory(Character character)
        {
            GPTForCharacter gPTForCharacter = new GPTForCharacter(); // перенеси это херь в сервис
            return await gPTForCharacter.GenerateStoryForCharacter(character);
        }

        public static T GetRandomEnumValue<T>()
        {
            Array enumValues = Enum.GetValues(typeof(T));
            Random random = new Random();
            int randomIndex = random.Next(enumValues.Length);
            return (T)enumValues.GetValue(randomIndex);
        }
    }
}
