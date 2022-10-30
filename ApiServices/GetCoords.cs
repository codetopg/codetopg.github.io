using codeTopGBlazorWasm.Models;
using Microsoft.JSInterop;

namespace codeTopGBlazorWasm.ApiServices
{
    public class GetCoords : IGetCoords, IDisposable
    {
        private readonly IJSRuntime jsRuntime;

        public GetCoords(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async Task<CoordsModel> GetCoord()
        {
            
            return await jsRuntime.InvokeAsync<CoordsModel>("getLocationInterop.getLocation");
           
        }

        public void Dispose()
        {

        }
    }
}
