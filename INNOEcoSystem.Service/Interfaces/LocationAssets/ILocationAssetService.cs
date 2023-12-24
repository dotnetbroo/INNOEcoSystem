using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Service.DTOs.LocationsAsset;
using Microsoft.AspNetCore.Http;

namespace INNOEcoSystem.Service.Interfaces.LocationAssets;

public interface ILocationAssetService
{
    Task<bool> RemoveAsync(long id);
    Task<LocationAssetForResultDto> RetrieveByIdAsync(long id);
    Task<LocationAssetForResultDto> CreateAsync(LocationAssetForCreationDto dto);
    Task<LocationAssetForResultDto> ModifyAsync(long id, LocationAssetForUpdateDto dto);
    Task<IEnumerable<LocationAssetForResultDto>> RetrieveAllAsync(PaginationParams @params);
}
