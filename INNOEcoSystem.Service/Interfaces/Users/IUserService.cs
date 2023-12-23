using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Service.DTOs.Users;

namespace INNOEcoSystem.Service.Interfaces.User;

public  interface IUserService
{
    Task<bool> RemoveAsync(long id);
    Task<UserForResultDto> RetrieveByIdAsync(long id);
    Task<UserForResultDto> AddAsync(UserForCreationDto dto);
    Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto);
    Task<bool> ChangePasswordAsync(string email, UserForChangePasswordDto dto);
    Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(PaginationParams @params);
    Task<IEnumerable<UserForResultDto>> RetrieveAllDeletedUsersAsync(PaginationParams @params);
    Task<bool> ForgetPasswordAsync(string PhoneNumber, string NewPassword, string ConfirmPassword);
}
