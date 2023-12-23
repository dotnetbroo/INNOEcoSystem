using AutoMapper;
using INNOEcoSystem.Data.IRepositories.LocationAssets;
using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Service.Commons.Helpers;
using INNOEcoSystem.Service.DTOs.LocationsAsset;
using INNOEcoSystem.Service.Exceptions;
using INNOEcoSystem.Service.Interfaces.LocationAssets;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace INNOEcoSystem.Service.Services.LocationAsset;

public class LocationAssetService : ILocationAssetService
{
    private readonly IMapper _mapper;
    private readonly ILocationAssetRepository _locationAssetRepository;

    public LocationAssetService(IMapper mapper, ILocationAssetRepository locationAssetRepository, WebHostEnviromentHelper webHostEnvironment)
    {
        _mapper = mapper;
        _locationAssetRepository = locationAssetRepository;
    }

    
        
    public async Task<LocationAssetForResultDto> CreateAsync(IFormFile formFile)
    {

        var location = await _locationAssetRepository.SelectAll()
        .Where(l => l.LacationId == l.LacationId)
        .AsNoTracking()
        .FirstOrDefaultAsync();

        if (location is not null)
            throw new INNOEcoSystemException(404, "Location is not found");


        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long userId, long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<LocationAssetForResultDto>> RetrieveAllAsync(long userId, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<LocationAssetForResultDto> RetrieveByIdAsync(long userId, long id)
    {
        throw new NotImplementedException();
    }
}
