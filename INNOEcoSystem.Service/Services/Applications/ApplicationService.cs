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
                .FirstOrDefaultAsync();

        if (application is not null)
            throw new INNOEcoSystemException(409, "Application is already exist.");

        var mappedApplication = _mapper.Map<Application>(dto);
        mappedApplication.CreatedAt = DateTime.UtcNow;

        var createdApplication = await _applicationRepository.InsertAsync(mappedApplication);
        return _mapper.Map<ApplicationForResultDto>(createdApplication);
    }

    public async Task<ApplicationForResultDto> ModifyAsync(long id, ApplicationForUpdateDto dto)
    {
        var application = await _applicationRepository.SelectAll()
                .Where(a => a.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

        if (application is null)
            throw new INNOEcoSystemException(404, "Application is not found");

        var mappedApplication = _mapper.Map(dto, application);
        mappedApplication.UpdatedAt = DateTime.UtcNow;

        await _applicationRepository.UpdateAsync(mappedApplication);

        return _mapper.Map<ApplicationForResultDto>(mappedApplication);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var application = await _applicationRepository.SelectAll()
                .Where(a => a.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

        if (application is null)
            throw new INNOEcoSystemException(404, "Application is not found");

        await _applicationRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<ApplicationForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var applications = await _applicationRepository.SelectAll()
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<ApplicationForResultDto>>(applications);
    }

    public async Task<ApplicationForResultDto> RetrieveByIdAsync(long id)
    {
        var application = await _applicationRepository.SelectAll()
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

        if (application is null)
            throw new INNOEcoSystemException(404, "Application is not found");

        return _mapper.Map<ApplicationForResultDto>(application);
    }
}
