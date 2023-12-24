using AutoMapper;
using Microsoft.EntityFrameworkCore;
using INNOEcoSystem.Service.Exceptions;
using INNOEcoSystem.Data.IRepositories;
using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Service.DTOs.Applications;
using INNOEcoSystem.Service.Commons.Extensions;
using INNOEcoSystem.Domain.Entities.Applications;
using INNOEcoSystem.Service.Interfaces.Applications;

namespace INNOEcoSystem.Service.Services.Applications;
public class ApplicationService : IApplicationService
{
    private readonly IMapper _mapper;
    private readonly IApplicationRepository _applicationRepository;

    public ApplicationService(IMapper mapper, IApplicationRepository applicationRepository)
    {
        _mapper = mapper;
        _applicationRepository = applicationRepository;
    }

    public async Task<ApplicationForResultDto> AddAsync(ApplicationForCreationDto dto)
    {
        var application = await _applicationRepository.SelectAll()
            .Where(a => a.DepartmentId == dto.DepartmentId && a.UserId == dto.UserId)
            .Where(a => a.IsDeleted == false)
            .FirstOrDefaultAsync();

        if (application is not null)
            throw new INNOEcoSystemException(409, "Application is already exist.");

        var imageFileName = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.Presentation.FileName);
        var imageRootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "Media", "Applications", "Presentations", imageFileName);
        using (var stream = new FileStream(imageRootPath, FileMode.Create))
        {
            await dto.Presentation.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }
        string imageResult = Path.Combine("Media", "Applications", "Presentations", imageFileName);

        var mappedApplication = _mapper.Map<Application>(dto);
        mappedApplication.CreatedAt = DateTime.UtcNow;

        mappedApplication.Number = new Random().Next(1000000, 9999999);
        mappedApplication.Presentation = imageResult;
        mappedApplication.Status = 0;

        var createdApplication = await _applicationRepository.InsertAsync(mappedApplication);
        return _mapper.Map<ApplicationForResultDto>(createdApplication);
    }

    public async Task<ApplicationForResultDto> ModifyAsync(long id, ApplicationForUpdateDto dto)
    {
        var application = await _applicationRepository.SelectAll()
                .Where(a => a.Id == id && a.IsDeleted == false)
                .AsNoTracking()
                .FirstOrDefaultAsync();

        if (application is null)
            throw new INNOEcoSystemException(404, "Application is not found");

        var imageFullPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, application.Presentation);

        if (File.Exists(imageFullPath))
            File.Delete(imageFullPath);

        var imageFileName = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.Presentation.FileName);
        var imageRootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "Media", "Applications","Presentations", imageFileName);
        using (var stream = new FileStream(imageRootPath, FileMode.Create))
        {
            await dto.Presentation.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }
        string imageResult = Path.Combine("Media", "Applications", "Presentations", imageFileName);

        var mappedApplication = _mapper.Map(dto, application);
        mappedApplication.UpdatedAt = DateTime.UtcNow;
        mappedApplication.Presentation = imageResult;
        mappedApplication.Status = 0;

        await _applicationRepository.UpdateAsync(mappedApplication);

        return _mapper.Map<ApplicationForResultDto>(mappedApplication);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var application = await _applicationRepository.SelectAll()
                .Where(a => a.Id == id && a.IsDeleted == false)
                .AsNoTracking()
                .FirstOrDefaultAsync();

        if (application is null)
            throw new INNOEcoSystemException(404, "Application is not found");

        var imageFullPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, application.Presentation);

        if (File.Exists(imageFullPath))
            File.Delete(imageFullPath);

        application.IsDeleted = true;
        await _applicationRepository.UpdateAsync(application);

        return true;
    }

    public async Task<IEnumerable<ApplicationForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var applications = await _applicationRepository.SelectAll()
            .Where(a => a.IsDeleted == false)
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<ApplicationForResultDto>>(applications);
    }

    public async Task<ApplicationForResultDto> RetrieveByIdAsync(long id)
    {
        var application = await _applicationRepository.SelectAll()
                .Where(a => a.Id == id && a.IsDeleted == false)
                .AsNoTracking()
                .FirstOrDefaultAsync();

        if (application is null)
            throw new INNOEcoSystemException(404, "Application is not found");

        return _mapper.Map<ApplicationForResultDto>(application);
    }

    public async Task<ApplicationForResultDto> SearchApplicationByNumberAsync(int num)
    {
        var application = await _applicationRepository.SelectAll()
                .Where(a => a.Number == num && a.IsDeleted == false)
                .AsNoTracking()
                .FirstOrDefaultAsync();

        if (application is null)
            throw new INNOEcoSystemException(404, "Application is not found");

        return _mapper.Map<ApplicationForResultDto>(application);
    }




    public async Task<IEnumerable<ApplicationForResultDto>> RetrieveAllDeletedApplicationAsync(PaginationParams @params)
    {
        var application = await _applicationRepository.SelectAll()
            .Where(u => u.IsDeleted == true)
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<ApplicationForResultDto>>(application);
    }
}
