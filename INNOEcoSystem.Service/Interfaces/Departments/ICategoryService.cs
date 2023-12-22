using INNOEcoSystem.Service.DTOs.Categories;

namespace INNOEcoSystem.Service.Interfaces.Departments;

public interface ICategoryService
{
    Task<bool> RemoveAsync(long id);
    Task<CategoryForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<CategoryForResultDto>> RetrieveAllAsync();
    Task<CategoryForResultDto> CreateAsync(CategoryForCreationDto dto);
    Task<CategoryForResultDto> ModifyAsync(long id, CategoryForUpdateDto dto);
}
