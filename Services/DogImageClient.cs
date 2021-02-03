

using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace DogImageApiCall.Services
{
    public class DogImageClient :IDogImageClient
    {
        private readonly HttpClient _client;

        public DogImageClient(HttpClient client)
        {
            _client = client;
        }
        public async Task<DogImageResponse> GetDogImage(string breed= "clumber")
        {
            var results = await _client.GetAsync($"/api/breed/{breed}/images");
            if (results.IsSuccessStatusCode)
            {
                var stringContent = await results.Content.ReadAsStringAsync();

                var toCamelCase = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
                var obj = JsonSerializer.Deserialize<DogImageResponse>(stringContent, toCamelCase);
                return obj;
            
            }
            else
            {
                throw new HttpRequestException("NO dogs 4(04) you");
            } 
        }
    }
}
