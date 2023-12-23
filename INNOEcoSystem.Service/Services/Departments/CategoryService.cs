using AutoMapper;
using INNOEcoSystem.Data.IRepositories.Categories;
using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Domain.Entities.Departments;
using INNOEcoSystem.Service.Commons.Extensions;
using INNOEcoSystem.Service.DTOs.Categories;
using INNOEcoSystem.Service.Exceptions;
using INNOEcoSystem.Service.Helpers;
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
            .Where(c => c.Name.ToLower() == dto.Name.ToLower())
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (existingCategory is not null)
            throw new INNOEcoSystemException(404, "Category is not found");

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

    public async Task<CategoryForResultDto> ModifyAsync(CategoryForUpdateDto dto)
    {
        var categoryToUpdate = await _categoryRepository.SelectAll()
            .Where(c => c.Name.ToLower() == dto.Name.ToLower())
            .AsNoTracking()
            .FirstOrDefaultAsync();

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
            .Where(c => c.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (existingCategory is not null)
            throw new INNOEcoSystemException(404, "Category is not found");

        #region Image
        var imageFilepath = Path.Combine(WebHostEnviromentHelper.WebRootPath, existingCategory.Image);

        if (File.Exists(imageFilepath))
            File.Delete(imageFilepath);
        #endregion

        return await _categoryRepository.DeleteAsync(id);

    }

    public async Task<IEnumerable<CategoryForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var existingCategory = await _categoryRepository
            .SelectAll()
            .AsNoTracking()
            .ToPagedList<Category>(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<CategoryForResultDto>>(existingCategory);

    }

    public async Task<CategoryForResultDto> RetrieveByIdAsync(long id)
    {
        var existingCategory = await _categoryRepository.SelectAll()
            .Where(c => c.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (existingCategory is not null)
            throw new INNOEcoSystemException(404, "Category is not found");

        return _mapper.Map<CategoryForResultDto>(existingCategory);

    }
}
