using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Service.DTOs.Address;

namespace INNOEcoSystem.Service.Interfaces.Locations;

public interface IAddressService
{
    Task<bool> RemoveAsync(long id);
    Task<AddressForResultDto> RetrieveByIdAsync(long id);
    Task<AddressForResultDto> ModifyAsync(long id, AddressForUpdateDto dto);
    Task<AddressForResultDto> CreateAsync(AddressForCreationDto dto);
    Task<IEnumerable<AddressForResultDto>> RetrieveAllAsync(PaginationParams @params);
    Task<IEnumerable<AddressForResultDto>> RetrieveAllDeletedUsersAddressAsync(PaginationParams @params);
}
