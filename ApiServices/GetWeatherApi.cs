using codeTopGBlazorWasm.Models;
using Microsoft.JSInterop;
using System.Text.Json;

namespace codeTopGBlazorWasm.ApiServices
{
    public class GetWeatherApi : IGetWeatherApi,IGetCoords
    {
        public CoordsModel location;

        private OpenWeatherModel weatherData;

        string _url = $"https://api.openweathermap.org/data/2.5/forecast?" +
            $"lat=10.844793" +
            $"&lon=106.711654" +
            $"&appid=1f7e64a683b4c7085e693af48155414a";

        //coods from js, Long  106.711654 Latitude 10.844793



        public async Task<CoordsModel> GetCoord()
        {
            location = await GetCoord();
            
            return location;
        }

        private HttpClient _httpClient;
       

        public GetWeatherApi(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new AggregateException(nameof(httpClient));
        }
        
        public async Task<OpenWeatherModel> GetForcast()
        {
            HttpClientConfig();
            var httpResponseMessage = await _httpClient.GetAsync(_url);
            httpResponseMessage.EnsureSuccessStatusCode();

            using var stream = await httpResponseMessage.Content.ReadAsStreamAsync();
            weatherData = await JsonSerializer.DeserializeAsync<OpenWeatherModel>(stream);
            Console.WriteLine("weatherData from API service"+ weatherData.city.name);
            return weatherData;
        }

        private async void HttpClientConfig()
        {
            
            Console.WriteLine("_url in HttpClient", _url);
            _httpClient.BaseAddress = new Uri(_url);
            Console.WriteLine("url from service "+_url);
        }

        
    }
}
