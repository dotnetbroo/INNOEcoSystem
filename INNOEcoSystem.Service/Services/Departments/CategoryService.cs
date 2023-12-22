using AutoMapper;
using INNOEcoSystem.Data.IRepositories.Categories;
using INNOEcoSystem.Domain.Entities.Departments;
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
        var @category = await _categoryRepository.SelectAll()
            .Where(c => c.Name.ToLower() == dto.Name.ToLower())
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (@category is not null)
            throw new INNOEcoSystemException(404, "Category is not found");

        var WwwRootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "Media", "Category");
        var AssetsFolderPath = Path.Combine(WwwRootPath, "Media");
        var ImagesFolderPath = Path.Combine(AssetsFolderPath, "Category");

        if (!Directory.Exists(AssetsFolderPath))
        {
            Directory.CreateDirectory(AssetsFolderPath);
        }

        if (!Directory.Exists(ImagesFolderPath))
        {
            Directory.CreateDirectory(ImagesFolderPath);
        }
        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.Image.FileName);

        var fullPath = Path.Combine(WwwRootPath, fileName);

        using (var stream = File.OpenWrite(fullPath))
        {
            await dto.Image.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }

        string resultImage = Path.Combine("Media", "Category", fileName);

        var mapped = _mapper.Map<Category>(dto);
        mapped.Image = resultImage;
        var result = await _categoryRepository.InsertAsync(mapped);

        return _mapper.Map<CategoryForResultDto>(result);

    }

    public async Task<CategoryForResultDto> ModifyAsync(long id, CategoryForUpdateDto dto)
    {
        var @category = await _categoryRepository.SelectAll()
            .Where(c => c.Name.ToLower() == dto.Name.ToLower())
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (@category is not null)
            throw new INNOEcoSystemException(404, "Category is not found");

        var fullPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, category.Image);

        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }

        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.Image.FileName);
        var rootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "Media", "Category", fileName);
        using (var stream = new FileStream(rootPath, FileMode.Create))
        {
            await dto.Image.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }
        string resultImage = Path.Combine("Media", "Category", fileName);

        var mapped = _mapper.Map(dto, category);
        mapped.Image = resultImage;
        mapped.UpdatedAt = DateTime.UtcNow;

        var result = await _categoryRepository.UpdateAsync(mapped);
        return _mapper.Map<CategoryForResultDto>(result);

    }

    public async Task<bool> RemoveAsync(long id)
    {
        var @category = await _categoryRepository.SelectAll()
            .Where(c => c.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (@category is not null)
            throw new INNOEcoSystemException(404, "Category is not found");

        var fullPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, category.Image);

        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }

        return await _categoryRepository.DeleteAsync(id);

    }

    public async Task<IEnumerable<CategoryForResultDto>> RetrieveAllAsync()
    {
        var categories = await _categoryRepository
            .SelectAll()
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<CategoryForResultDto>>(categories);

    }

    public async Task<CategoryForResultDto> RetrieveByIdAsync(long id)
    {
        var @category = await _categoryRepository.SelectAll()
            .Where(c => c.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (@category is not null)
            throw new INNOEcoSystemException(404, "Category is not found");

        return _mapper.Map<CategoryForResultDto>(category);

    }
}
