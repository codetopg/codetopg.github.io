using codeTopGBlazorWasm.Models;

namespace codeTopGBlazorWasm.ApiServices
{
    public interface IGetCoords
    {
        Task<CoordsModel> GetCoord();
    }
}
