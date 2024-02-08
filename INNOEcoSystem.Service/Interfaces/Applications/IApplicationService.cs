using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Domain.Enums;
using INNOEcoSystem.Service.DTOs.Applications;

namespace INNOEcoSystem.Service.Interfaces.Applications;

public interface IApplicationService
{
    Task<bool> RemoveAsync(long id);
    Task<ApplicationForResultDto> RetrieveByIdAsync(long id);
    Task<ApplicationForResultDto> SearchApplicationByNumberAsync(int num);
    Task<ApplicationForResultDto> AddAsync(ApplicationForCreationDto dto);
    Task<IEnumerable<ApplicationForResultDto>> RetrieveAllAsync(PaginationParams @params);
    Task<IEnumerable<ApplicationForResultDto>> RetrieveAllDeletedApplicationAsync(PaginationParams @params);
    Task<ApplicationForResultDto> ModifyAsync(long id, ApplicationForUpdateDto dto);
    Task<ApplicationForResultDto> ModifyApplicationStatusAsync(long id, ApplicationStatus status);
}
