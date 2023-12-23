using INNOEcoSystem.Service.DTOs.Categories;
using INNOEcoSystem.Service.Interfaces.Departments;
using Microsoft.AspNetCore.Mvc;
using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Api.Controllers.Commons;
using INNOEcoSystem.Service.DTOs.Users;

namespace INNOEcoSystem.Api.Controllers.Categories;

public class CategoriesController : BaseController
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromForm] CategoryForCreationDto dto)
       => Ok(await _categoryService.CreateAsync(dto));

    [HttpGet("retrieve-categories")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _categoryService.RetrieveAllAsync(@params));

    [HttpGet("retrieve-deleted-categories")]
    public async Task<IActionResult> GetAllDeletedCategoryAsync([FromQuery] PaginationParams @params)
        => Ok(await _categoryService.RetrieveAllDeletedCategoriesAsync(@params));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(await _categoryService.RetrieveByIdAsync(id));

    [HttpGet("search-with-name")]
    public async Task<IActionResult> SearchByNameAsync(string name)
        => Ok(await _categoryService.RetrieveByNameAsync(name));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(await _categoryService.RemoveAsync(id));

    [HttpPut("modify-category-picture{categoryId}")]
    public async Task<IActionResult> PutUserImageAsync([FromRoute(Name = "categoryId")] long categoryId, [FromForm] CategoryImageForUpdateDto dto)
            => Ok(await this._categoryService.ModifyCategoryImageAsunc(categoryId, dto));

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromForm] CategoryForUpdateDto dto)
        => Ok(await _categoryService.ModifyAsync(id, dto));
}
