using codeTopGBlazorWasm.Models;
using Microsoft.JSInterop;

namespace codeTopGBlazorWasm.ApiServices
{
    public class GetCoords : IGetCoords, IDisposable
    {
        public readonly IJSRuntime jsRuntime;

        public GetCoords(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async Task<CoordsModel> GetCoord()
        {
            //CoordsModel coords;
            return await jsRuntime.InvokeAsync<CoordsModel>("getLocationInterop.getLocation");
            //Console.WriteLine("coord form GetCoord"+ coords.Longitude.ToString() + coords.Latitude.ToString());
            //return coords;
        }

        public void Dispose()
        {
        }
    }
}
