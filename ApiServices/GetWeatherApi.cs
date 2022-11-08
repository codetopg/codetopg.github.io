using codeTopGBlazorWasm.Models;
using System.Text;
using System.Text.Json;

namespace codeTopGBlazorWasm.ApiServices
{
    public class GetWeatherApi : IGetWeatherApi, IDisposable
    {
        public CoordsModel location;
        private OpenWeatherModel weatherData;
        private readonly HttpClient _httpClient;
        readonly StringBuilder myUrl = new();

        public GetWeatherApi(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new AggregateException(nameof(httpClient));
        }

        public async Task<OpenWeatherModel> GetForcast(double lon, double lat)
        {
            //HttpClientConfig();
            //Console.WriteLine("LOCATION " + lat + lon);
            myUrl.Clear();
            myUrl.Append("https://api.openweathermap.org/data/2.5/forecast?");
            myUrl.Append($"lat={lat}");
            myUrl.Append($"&lon={lon}");
            myUrl.Append("&units=metric");
            myUrl.Append("&appid=1f7e64a683b4c7085e693af48155414a");

            //Console.WriteLine("my url from cs " + myUrl);

            var httpResponseMessage = await _httpClient.GetAsync(myUrl.ToString());
            httpResponseMessage.EnsureSuccessStatusCode();

            using var stream = await httpResponseMessage.Content.ReadAsStreamAsync();
            weatherData = await JsonSerializer.DeserializeAsync<OpenWeatherModel>(stream);
            //Console.WriteLine("weatherData from API service " + weatherData?.city.name);
            return weatherData;
        }

        //private void HttpClientConfig()
        //{
        //    location = await coords.GetCoord();
        //    var lat;
        //    IgetCoords.GetCoord().Result.Latitude lat = new();
        //    IgetCoords.GetCoord().Result.Longitude = new();



        //    Console.WriteLine("LOCATION" + lat + lon);
        //    myUrl.Append("https://api.openweathermap.org/data/2.5/forecast?");
        //    myUrl.Append($"lat={lat}");
        //    myUrl.Append($"&lon={lon}");
        //    myUrl.Append("&appid=1f7e64a683b4c7085e693af48155414a");


        //    Console.WriteLine("_url in HttpClient", _url);
        //    _httpClient.BaseAddress = new Uri(_url);

        //}
        public void Dispose() => _httpClient.Dispose();
    }
}
