using System.Text;
using System.Text.Json;

namespace Lab1_DnD_Creator.wwwroot.client
{
    class GPTClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public GPTClient(string apiKey)
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey;
        }

        public async Task<string> GetChatGPTResponseAsync(string prompt)
        {
            var request = new
            {
                prompts = new[] { prompt },
                model = "gpt-3.5-turbo",
                max_tokens = 150,
                temperature = 0.7
            };

            var jsonContent = JsonSerializer.Serialize(request);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/completions", content);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var responseObject = JsonSerializer.Deserialize<dynamic>(responseBody);

                return responseObject.choices[0].text;
            }
            else
            {
                var msg = await response.Content.ReadAsStringAsync();
                throw new Exception($"Request failed with status code: {response.StatusCode}. {msg}");
            }
        }
    }
}
