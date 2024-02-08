using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Service.DTOs.Users;

namespace INNOEcoSystem.Service.Interfaces.User;

public interface IUserService
{
    Task<bool> RemoveAsync(long id);
    Task<UserForResultDto> RetrieveByIdAsync(long id);
    Task<UserForResultDto> AddAsync(UserForCreationDto dto);
    Task<UserForResultDto> AddAdminAsync(UserForCreationDto dto);
    Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto);
    Task<bool> ChangePasswordAsync(string email, UserForChangePasswordDto dto);
    Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(PaginationParams @params);
    Task<UserImageResultDto> ModifyUserImageAsunc(long userId, UserImageUpdateDto dto);
    Task<IEnumerable<UserForResultDto>> RetrieveAllAdminsAsync(PaginationParams @params);
    Task<IEnumerable<UserForResultDto>> RetrieveAllDeletedUsersAsync(PaginationParams @params);
    Task<IEnumerable<UserForResultDto>> SearchAllAsync(string search, PaginationParams @params);
    Task<IEnumerable<UserForResultDto>> RetrieveAllDepartmentAdminsAsync(PaginationParams @params);
    Task<IEnumerable<UserForResultDto>> SearchAdminsAsync(string search, PaginationParams @params);
    Task<bool> ForgetPasswordAsync(string PhoneNumber, string NewPassword, string ConfirmPassword);
    Task<IEnumerable<UserForResultDto>> SearchAllDeparmentAdminAsync(string search, PaginationParams @params);
}
