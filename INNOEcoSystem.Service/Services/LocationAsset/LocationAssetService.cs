using AutoMapper;
using INNOEcoSystem.Data.IRepositories.LocationAssets;
using INNOEcoSystem.Data.IRepositories.Locations;
using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Domain.Entities.Assets;
using INNOEcoSystem.Service.Commons.Extensions;
using INNOEcoSystem.Service.Commons.Helpers;
using INNOEcoSystem.Service.DTOs.LocationsAsset;
using INNOEcoSystem.Service.Exceptions;
using INNOEcoSystem.Service.Interfaces.LocationAssets;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace INNOEcoSystem.Service.Services;

public class LocationAssetService : ILocationAssetService
{
    private readonly IMapper _mapper;
    private readonly ILocationAssetRepository _locationAssetRepository;
    private readonly ILocationRepository _locationRepository;

    public LocationAssetService(IMapper mapper,
        ILocationAssetRepository locationAssetRepository,
        ILocationRepository locationRepository)
    {
        _mapper = mapper;
        _locationRepository = locationRepository;
        _locationAssetRepository = locationAssetRepository;
    }



    public async Task<LocationAssetForResultDto> CreateAsync(long Id, IFormFile formFile)
    {

        var location = await _locationRepository.SelectAll()
           .Where(c => c.Id == Id)
           .AsNoTracking()
           .FirstOrDefaultAsync();

        if (location is null || location?.IsDeleted == true)
        {
            throw new INNOEcoSystemException(404, "Location is not found");
        }


        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(formFile.FileName);
        var rootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "Media", "Locations", "Assets", fileName);

        using (var stream = new FileStream(rootPath, FileMode.Create))
        {
            await formFile.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }

        var mappedAsset = new LocationAsset()
        {
            Id = Id,
            LacationId = Id,
            Name = formFile.Name,
            Size = formFile.Length,
            Type = formFile.ContentType,
            CreatedAt = DateTime.UtcNow,
            Extension = Path.GetExtension(formFile.FileName),
            Path = Path.Combine("Media", "Locations", "Assets", formFile.FileName)
        };

        var result = await _locationAssetRepository.InsertAsync(mappedAsset);

        return _mapper.Map<LocationAssetForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long locationId, long id)
    {
        var location = await _locationRepository.SelectAll()
            .Where(l => l.Id == locationId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (location is null || location?.IsDeleted == true)
            throw new INNOEcoSystemException(404, "Location is not found");

        var locationAsset = await _locationAssetRepository.SelectAll()
            .Where(locationAsset => locationAsset.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (locationAsset is null || locationAsset?.IsDeleted == true)
            throw new INNOEcoSystemException(404, "Location Asset is not found");

        return await _locationAssetRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<LocationAssetForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {

        var LocationAssets = await _locationAssetRepository.SelectAll()
            .ToPagedList(@params)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<LocationAssetForResultDto>>(LocationAssets);

    }

    public async Task<LocationAssetForResultDto> RetrieveByIdAsync(long locationId, long id)
    {
        var locationAsset = await _locationRepository.SelectAll()
            .Where(l => l.Id == locationId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (locationAsset is null || locationAsset?.IsDeleted == true)
            throw new INNOEcoSystemException(404, "Location is not found");

        return _mapper.Map<LocationAssetForResultDto>(locationAsset);

    }
}
