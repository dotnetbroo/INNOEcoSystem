using AutoMapper;
using INNOEcoSystem.Service.Helpers;
using Microsoft.EntityFrameworkCore;
using INNOEcoSystem.Service.Exceptions;
using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Service.DTOs.Department;
using INNOEcoSystem.Service.DTOs.Departments;
using INNOEcoSystem.Service.Commons.Extensions;
using INNOEcoSystem.Domain.Entities.Departments;
using INNOEcoSystem.Service.DTOs.DepartmentAssets;
using INNOEcoSystem.Service.Interfaces.Department;
using INNOEcoSystem.Data.IRepositories.Depsrtments;
using INNOEcoSystem.Data.IRepositories.Categories;

namespace INNOEcoSystem.Service.Services;

public  class DepartmentService : IDepartmentService
{
    private readonly IMapper _mapper;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly ICategoryRepository _categoryRepository;

    public DepartmentService(IMapper mapper,ICategoryRepository categoryRepository, IDepartmentRepository departmentRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
        _departmentRepository = departmentRepository;
    }

    public async Task<DepartmentForResultDto> AddAsync(DepartmentForCreationDto departmentForCreationDto)
    {
        var department = await _departmentRepository.SelectAll()
            .Where(d => d.Name == departmentForCreationDto.Name)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (department is not  null || department?.IsDeleed == true)
            throw new INNOEcoSystemException(404, "Department is not found");

        var category = await _categoryRepository.SelectAll()
            .Where(c=>c.Id == departmentForCreationDto.CategoryId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (category is null || category?.IsDeleed == true)
            throw new INNOEcoSystemException(404, "Category is not found");

        

        var mappedDepartment = _mapper.Map<Department>(departmentForCreationDto);
        mappedDepartment.CreatedAt = DateTime.UtcNow;
        var createDepartment = await _departmentRepository.InsertAsync(mappedDepartment);
        return _mapper.Map<DepartmentForResultDto>(createDepartment);
    }

    public async Task<DepartmentForResultDto> CreateLicenseAsync(long id, DepartmentAssetForCreationDto departmentAssetForCreationDto)
    {
        var department = await _departmentRepository.SelectAll()
            .Where(e => e.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (department is null)
            throw new INNOEcoSystemException(404, "Department is not found");

        if (department.License is not null)
            throw new INNOEcoSystemException(409, "Department License already exicts");

        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(departmentAssetForCreationDto.formFile.FileName);
        var rootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "Media", "Departments", "Licenses", fileName);
        using (var stream = new FileStream(rootPath, FileMode.Create))
        {
            await departmentAssetForCreationDto.formFile.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }
        string bannerPath = Path.Combine("Media", "Departments", "Licenses", fileName);

        department.License = bannerPath;

        var mappedDepartment = _mapper.Map<Department>(department);
        var communityResult = await _departmentRepository.UpdateAsync(mappedDepartment);

        return _mapper.Map<DepartmentForResultDto>(communityResult);
    }

    public async Task<DepartmentForResultDto> CreateLogoAsync(long id, DepartmentAssetForCreationDto departmentAssetForCreationDto)
    {
        var department = await _departmentRepository.SelectAll()
            .Where(e => e.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (department is null)
            throw new INNOEcoSystemException(404, "Department is not found");

        if (department.Logo is not null)
            throw new INNOEcoSystemException(409, "Department Logo already exicts");

        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(departmentAssetForCreationDto.formFile.FileName);
        var rootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "Media", "Departments", "Logos", fileName);
        using (var stream = new FileStream(rootPath, FileMode.Create))
        {
            await departmentAssetForCreationDto.formFile.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }

        string bannerPath = Path.Combine("Media", "Departments", "Logos", fileName);

        department.License = bannerPath;

        var mappedDepartment = _mapper.Map<Department>(department);
        var communityResult = await _departmentRepository.UpdateAsync(mappedDepartment);

        return _mapper.Map<DepartmentForResultDto>(communityResult);
        throw new NotImplementedException();
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var department = await _departmentRepository.SelectAll()
            .Where(d => d.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (department is null || department.IsDeleed == true)
            throw new INNOEcoSystemException(404, "Department is not found");

        department.IsDeleed = true;
        var mappedDepartment = _mapper.Map<Department>(department);
        var deleteDepartment = await _departmentRepository.UpdateAsync(mappedDepartment);

        return deleteDepartment.IsDeleed;

    }

    public async Task<IEnumerable<DepartmentForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var departments = await _departmentRepository.SelectAll()
            .Where(d => d.IsDeleed == false)
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<DepartmentForResultDto>>(departments);


    }

    public async Task<DepartmentForResultDto> RetrieveByIdAsync(long id)
    {
        var department = await _departmentRepository.SelectAll()
            .Where(d => d.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (department is null || department.IsDeleed == true)
            throw new INNOEcoSystemException(404, "Department is not found");

        return _mapper.Map<DepartmentForResultDto>(department);
    }

    public async Task<DepartmentForResultDto> ModifyAsync(long id, DepartmentForUpdateDto departmentForUpdateDto)
    {
        var department = await _departmentRepository.SelectAll()
            .Where(d => d.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (department is null || department.IsDeleed == true)
            throw new INNOEcoSystemException(404, "Department is not found");

        var mappedDepartment = _mapper.Map<Department>(departmentForUpdateDto);
        mappedDepartment.UpdatedAt = DateTime.UtcNow;
        var updateDepartment = await _departmentRepository.UpdateAsync(mappedDepartment);
        return _mapper.Map<DepartmentForResultDto>(updateDepartment);


    }

    public async Task<DepartmentForResultDto> UpdateLicenseAsync(long id, DepartmentAssetForCreationDto departmentAssetForCreationDto)
    {
        var department = await _departmentRepository.SelectAll()
           .Where(e => e.Id == id)
           .FirstOrDefaultAsync();

        if (department is null || department.IsDeleed == true)
            throw new INNOEcoSystemException(404, "Department is not found");

        if (!string.IsNullOrEmpty(department.License))
        {
            var existingLogoPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, department.License);
            if (File.Exists(existingLogoPath))
            {
                File.Delete(existingLogoPath);
            }
        }

        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(departmentAssetForCreationDto.formFile.FileName);
        var rootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "Media", "Departments", "Licenses", fileName);

        using (var stream = new FileStream(rootPath, FileMode.Create))
        {
            await departmentAssetForCreationDto.formFile.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }

        string resulLicense = Path.Combine("Media", "Departments", "Licenses", fileName);

        department.License = resulLicense;
        var mappedDepartment = _mapper.Map<Department>(department);
        var result = await _departmentRepository.UpdateAsync(mappedDepartment);

        return _mapper.Map<DepartmentForResultDto>(result);

    }

    public async Task<DepartmentForResultDto> UpdateLogoAsync(long id, DepartmentAssetForCreationDto departmentAssetForCreationDto)
    {

        var department = await _departmentRepository.SelectAll()
          .Where(e => e.Id == id)
          .FirstOrDefaultAsync();

        if (department is null)
            throw new INNOEcoSystemException(404, "Department is not found");

        if (!string.IsNullOrEmpty(department.Logo))
        {
            var existingLogoPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, department.Logo);
            if (File.Exists(existingLogoPath))
            {
                File.Delete(existingLogoPath);
            }
        }

        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(departmentAssetForCreationDto.formFile.FileName);
        var rootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "Media", "Departments", "Logos", fileName);

        using (var stream = new FileStream(rootPath, FileMode.Create))
        {
            await departmentAssetForCreationDto.formFile.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }

        string resulLicense = Path.Combine("Media", "Departments", "Logos", fileName);

        department.Logo = resulLicense;
        var mappedDepartment = _mapper.Map<Department>(department);
        var result = await _departmentRepository.UpdateAsync(mappedDepartment);

        return _mapper.Map<DepartmentForResultDto>(result);

    }

}
