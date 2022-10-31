using codeTopGBlazorWasm.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text;
using System.Text.Json;

namespace codeTopGBlazorWasm.ApiServices
{
    public class GetWeatherApi : IGetWeatherApi
    {
        [Inject]
        public IGetCoords IgetCoords { get; set; }
       
        public CoordsModel location;
       
        private OpenWeatherModel weatherData;




        string _url = $"https://api.openweathermap.org/data/2.5/forecast?" +
            $"lat=10.844793" +
            $"&lon=106.711654" +
            $"&appid=1f7e64a683b4c7085e693af48155414a";

        //coods from js, Long  106.711654 Latitude 10.844793



        StringBuilder myUrl = new();
        

        private HttpClient _httpClient;
       

        public GetWeatherApi(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new AggregateException(nameof(httpClient));
        }


        public async Task<OpenWeatherModel> GetForcast()
        {
            HttpClientConfig();
            var httpResponseMessage = await _httpClient.GetAsync(myUrl.ToString());
            httpResponseMessage.EnsureSuccessStatusCode();

            using var stream = await httpResponseMessage.Content.ReadAsStreamAsync();
            weatherData = await JsonSerializer.DeserializeAsync<OpenWeatherModel>(stream);
            Console.WriteLine("weatherData from API service"+ weatherData.city.name);
            return weatherData;
        }

        private async void HttpClientConfig()
        {
            //location = await coords.GetCoord();
            //var lat;
            //IgetCoords.GetCoord().Result.Latitude lat = new();
            //IgetCoords.GetCoord().Result.Longitude = new();

           

            //Console.WriteLine("LOCATION" + lat + lon);
            //myUrl.Append("https://api.openweathermap.org/data/2.5/forecast?");
            //myUrl.Append($"lat={lat}");
            //myUrl.Append($"&lon={lon}");
            //myUrl.Append("&appid=1f7e64a683b4c7085e693af48155414a");

            
            Console.WriteLine("_url in HttpClient", _url);
            _httpClient.BaseAddress = new Uri(_url);
           
        }

        
    }
}
