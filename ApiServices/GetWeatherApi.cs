using codeTopGBlazorWasm.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace codeTopGBlazorWasm.ApiServices
{
    public class GetWeatherApi : IGetWeatherApi, IDisposable
    {
        public CoordsModel location;
        private OpenWeatherModel? weatherData;
        private readonly HttpClient _httpClient;
        readonly StringBuilder myUrl = new();

        public GetWeatherApi(HttpClient httpClientFactory)
        {
            _httpClient = httpClientFactory;
        }

        public async Task<OpenWeatherModel> GetForcast(double lon, double lat)
        {
            HttpClientConfig(lon, lat);  
            var httpResponseMessage = await _httpClient.GetAsync(myUrl.ToString());
            httpResponseMessage.EnsureSuccessStatusCode();
            using var stream = await httpResponseMessage.Content.ReadAsStreamAsync();
            weatherData = await JsonSerializer.DeserializeAsync<OpenWeatherModel>(stream);
            return weatherData;
        }

        private StringBuilder HttpClientConfig(double lon, double lat)
        {
            myUrl.Clear();
            myUrl.Append("https://api.openweathermap.org/data/2.5/forecast?");
            myUrl.Append($"lat={lat}");
            myUrl.Append($"&lon={lon}");
            myUrl.Append("&units=metric");
            myUrl.Append("&appid=1f7e64a683b4c7085e693af48155414a");
            //Console.WriteLine("myurl from httpclinet "+ myUrl);
            return myUrl;
        }
        public void Dispose() => _httpClient.Dispose();
    }
}
