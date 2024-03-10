namespace Lab1_DnD_Creator.wwwroot.client
{
    using Lab1_DnD_Creator.Models.Characters;
    using System.Configuration;
    public class GPTForCharacter
    {
        private GPTClient gPTClient;

        const string apiKey = "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";

        public GPTForCharacter()
        {
            gPTClient = new GPTClient(apiKey);
        }

        public async Task<string> GenerateStoryForCharacter(Character character)
        {
            string request = $"Сгенерируй короткую предысторию для персонажа в днд, его класс {character.CharClass} его раса - {character.Race}";
            
            return await gPTClient.GetChatGPTResponseAsync(request);
        }
    }
}
