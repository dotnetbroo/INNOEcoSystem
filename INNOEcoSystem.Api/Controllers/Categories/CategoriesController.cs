﻿using INNOEcoSystem.Service.DTOs.Categories;
using INNOEcoSystem.Service.Interfaces.Departments;
using Microsoft.AspNetCore.Mvc;
using INNOEcoSystem.Domain.Configurations;

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
       => Ok(await this._categoryService.CreateAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await this._categoryService.RetrieveAllAsync(@params));


    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
        => Ok(await this._categoryService.RetrieveByIdAsync(id));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
        => Ok(await this._categoryService.RemoveAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] [FromForm] CategoryForUpdateDto dto)
        => Ok(await this._categoryService.ModifyAsync(dto));
}
