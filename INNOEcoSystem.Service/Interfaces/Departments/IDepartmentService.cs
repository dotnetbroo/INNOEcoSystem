using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Service.DTOs.Department;
using INNOEcoSystem.Service.DTOs.Departments;
using INNOEcoSystem.Service.DTOs.DepartmentAssets;

namespace INNOEcoSystem.Service.Interfaces.Department;

public  interface IDepartmentService
{
    public Task<bool> RemoveAsync(long id);
    public Task<DepartmentForResultDto> RetrieveByIdAsync(long id);
    public Task<IEnumerable<DepartmentForResultDto>> RetrieveAllAsync(PaginationParams @params);
    public Task<DepartmentForResultDto> ModifyAsync(long id, DepartmentForUpdateDto departmentForUpdateDto);
    public Task<DepartmentForResultDto> AddAsync(DepartmentForCreationDto departmentForCreationDto);
    public Task<DepartmentForResultDto> UpdateLogoAsync(long id, DepartmentAssetForCreationDto departmentAssetForCreationDto);
    public Task<DepartmentForResultDto> CreateLogoAsync(long id, DepartmentAssetForCreationDto departmentAssetForCreationDto);
    public Task<DepartmentForResultDto> CreateLicenseAsync(long id, DepartmentAssetForCreationDto departmentAssetForCreationDto);
    public Task<DepartmentForResultDto> UpdateLicenseAsync(long id, DepartmentAssetForCreationDto DepartmentAssetForCreationDto);
}
