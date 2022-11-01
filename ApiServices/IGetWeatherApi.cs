using codeTopGBlazorWasm.Models;

namespace codeTopGBlazorWasm.ApiServices
{
    public interface IGetWeatherApi
    {
        Task<OpenWeatherModel> GetForcast(double lon, double lat);
    }
}
