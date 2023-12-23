using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Service.DTOs.LocationsAsset;
using Microsoft.AspNetCore.Http;

namespace INNOEcoSystem.Service.Interfaces.LocationAssets;

public  interface ILocationAssetService
{
    Task<bool> RemoveAsync(long id);
    Task<LocationAssetForResultDto> RetrieveByIdAsync(long id);
    Task<LocationAssetForResultDto> CreateAsync(IFormFile formFile);
    Task<IEnumerable<LocationAssetForResultDto>> RetrieveAllAsync(long id, PaginationParams @params);
}
