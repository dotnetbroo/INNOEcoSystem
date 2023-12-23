using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Service.DTOs.Categories;
using INNOEcoSystem.Service.DTOs.Locations;

namespace INNOEcoSystem.Service.Interfaces.Location;

public  interface ILocationService
{
    Task<bool> RemoveAsync(long id);
    Task<LocationForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<LocationForResultDto>> RetrieveAllAsync(PaginationParams @params);
    Task<LocationForResultDto> CreateAsync(LocationForCreationDto dto);
    Task<LocationForResultDto> ModifyAsync(long id, LocationForUpdateDto dto);
}
