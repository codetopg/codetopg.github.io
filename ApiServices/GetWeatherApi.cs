using codeTopGBlazorWasm.Models;
using Microsoft.JSInterop;
using System.Text.Json;

namespace codeTopGBlazorWasm.ApiServices
{
    public class GetWeatherApi
    {
        private Coord? position;
        private OpenWeatherModel weatherData;
        private string? _url;
        private HttpClient _httpClient;
       

        public GetWeatherApi(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new AggregateException(nameof(httpClient));
            
        }
        
        public async Task GetForcast()
        {
            string APIKey = "1f7e64a683b4c7085e693af48155414a";


            _url = $"api.openweathermap.org/data/2.5/forecast?" +
                $"lat={position.lat}" +
                $"&lon={position.lon}" +
                $"&appid={APIKey}";

            Console.WriteLine(_url);
            var httpResponseMessage = await _httpClient.GetAsync(_url);
            httpResponseMessage.EnsureSuccessStatusCode();

            var stream = await httpResponseMessage.Content.ReadAsStringAsync();
            weatherData = JsonSerializer.Deserialize<OpenWeatherModel>(stream);

        }       
    }
}
