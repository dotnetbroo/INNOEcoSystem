using AutoMapper;
using INNOEcoSystem.Data.IRepositories.Categories;
using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Domain.Entities.Departments;
using INNOEcoSystem.Service.Commons.Extensions;
using INNOEcoSystem.Service.Commons.Helpers;
using INNOEcoSystem.Service.DTOs.Categories;
using INNOEcoSystem.Service.Exceptions;
using INNOEcoSystem.Service.Interfaces.Departments;
using Microsoft.EntityFrameworkCore;

namespace INNOEcoSystem.Service.Services.Departments;

public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(
        IMapper mapper,
        ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryForResultDto> CreateAsync(CategoryForCreationDto dto)
    {
        var existingCategory = await _categoryRepository.SelectAll()
            .Where(c => c.Name.ToLower() == dto.Name.ToLower() && c.IsDeleted == false)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (existingCategory is not null)
            throw new INNOEcoSystemException(400, "Category is already exists");

        #region Image
        var imageFileName = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.Image.FileName);
        var imageRootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "Media", "Categories", "Images", imageFileName);
        using (var stream = new FileStream(imageRootPath, FileMode.Create))
        {
            await dto.Image.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }
        string imageResult = Path.Combine("Media", "Categories", "Images", imageFileName);
        #endregion

        var mapped = _mapper.Map<Category>(dto);
        mapped.CreatedAt = DateTime.UtcNow;
        mapped.Image = imageResult;

        var result = await _categoryRepository.InsertAsync(mapped);

        return _mapper.Map<CategoryForResultDto>(result);

    }

    public async Task<CategoryForResultDto> ModifyAsync(long id, CategoryForUpdateDto dto)
    {
        var categoryToUpdate = await _categoryRepository.SelectAsync(u => u.Id == id && u.IsDeleted == false);

        if (categoryToUpdate is not null)
            throw new INNOEcoSystemException(404, "Category is not found");

        #region Image
        var imageFilepath = Path.Combine(WebHostEnviromentHelper.WebRootPath, categoryToUpdate.Image);

        if (File.Exists(imageFilepath))
            File.Delete(imageFilepath);

        var imageFileName = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.Image.FileName);
        var imageRootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "Media", "Categories", "Images", imageFileName);
        using (var stream = new FileStream(imageRootPath, FileMode.Create))
        {
            await dto.Image.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }
        string imageResult = Path.Combine("Media", "Categories", "Images", imageFileName);

        #endregion

        var mapped = this._mapper.Map(dto, categoryToUpdate);
        mapped.UpdatedAt = DateTime.UtcNow;
        mapped.Image = imageResult;

        await this._categoryRepository.UpdateAsync(mapped);

        return _mapper.Map<CategoryForResultDto>(mapped);

    }

    public async Task<bool> RemoveAsync(long id)
    {
        var existingCategory = await _categoryRepository.SelectAll()
            .Where(c => c.Id == id && c.IsDeleted == false)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (existingCategory is not null)
            throw new INNOEcoSystemException(404, "Category is not found");

        #region Image
        var imageFilepath = Path.Combine(WebHostEnviromentHelper.WebRootPath, existingCategory.Image);

        if (File.Exists(imageFilepath))
            File.Delete(imageFilepath);
        #endregion

        existingCategory.IsDeleted = true;
        await _categoryRepository.UpdateAsync(existingCategory);

        return true;

    }

    public async Task<IEnumerable<CategoryForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var existingCategory = await _categoryRepository
            .SelectAll()
            .Where(c => c.IsDeleted == false)
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<CategoryForResultDto>>(existingCategory);

    }

    public async Task<IEnumerable<CategoryForResultDto>> RetrieveAllDeletedCategoriesAsync(PaginationParams @params)
    {
        var existingCategory = await _categoryRepository
            .SelectAll()
            .Where(c => c.IsDeleted == true)
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<CategoryForResultDto>>(existingCategory);

    }

    public async Task<CategoryForResultDto> RetrieveByIdAsync(long id)
    {
        var existingCategory = await _categoryRepository.SelectAll()
            .Where(c => c.Id == id && c.IsDeleted == false)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (existingCategory is not null)
            throw new INNOEcoSystemException(404, "Category is not found");

        return _mapper.Map<CategoryForResultDto>(existingCategory);

    }

    public async Task<CategoryForResultDto> RetrieveByNameAsync(string name)
    {
        var existingCategory = await _categoryRepository.SelectAll()
            .Where(c => c.Name == name && c.IsDeleted == false)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (existingCategory is not null)
            throw new INNOEcoSystemException(404, "Category is not found");

        return _mapper.Map<CategoryForResultDto>(existingCategory);
    }

    public async Task<CategoryImageForResultDto> ModifyCategoryImageAsunc(long categoryId, CategoryImageForUpdateDto dto)
    {
        var category = await _categoryRepository.SelectAsync(u => u.Id == categoryId && u.IsDeleted == false);
        if (category is null)
            throw new INNOEcoSystemException(404, "User is not found");

        var imageFullPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, category.Image);

        if (File.Exists(imageFullPath))
            File.Delete(imageFullPath);

        var imageFileName = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.Image.FileName);
        var imageRootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "Media", "Categories", "Images", imageFileName);
        using (var stream = new FileStream(imageRootPath, FileMode.Create))
        {
            await dto.Image.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }
        string imageResult = Path.Combine("Media", "Categories", "Images", imageFileName);

        var mappedImage = _mapper.Map(dto, category);
        mappedImage.Image = imageResult;

        return _mapper.Map<CategoryImageForResultDto>(mappedImage);
    }
}
