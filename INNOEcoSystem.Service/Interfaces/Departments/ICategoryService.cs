using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Service.DTOs.Categories;

namespace INNOEcoSystem.Service.Interfaces.Departments;

public interface ICategoryService
{
    Task<bool> RemoveAsync(long id);
    Task<CategoryForResultDto> RetrieveByIdAsync(long id);
    Task<CategoryForResultDto> RetrieveByNameAsync(string name);
    Task<CategoryForResultDto> CreateAsync(CategoryForCreationDto dto);
    Task<CategoryForResultDto> ModifyAsync(long id, CategoryForUpdateDto dto);
    Task<IEnumerable<CategoryForResultDto>> RetrieveAllAsync(PaginationParams @params);
    Task<IEnumerable<CategoryForResultDto>> RetrieveAllDeletedCategoriesAsync(PaginationParams @params);
    Task<CategoryImageForResultDto> ModifyCategoryImageAsunc(long categoryId, CategoryImageForUpdateDto dto);
}
