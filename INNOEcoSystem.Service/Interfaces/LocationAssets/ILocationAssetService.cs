using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Service.DTOs.LocationsAsset;
using Microsoft.AspNetCore.Http;

namespace INNOEcoSystem.Service.Interfaces.LocationAssets;

public  interface ILocationAssetService
{
    Task<bool> RemoveAsync(long userId, long id);
    Task<LocationAssetForResultDto> RetrieveByIdAsync(long userId, long id);
    Task<LocationAssetForResultDto> CreateAsync(long Id,IFormFile formFile);
    Task<IEnumerable<LocationAssetForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
