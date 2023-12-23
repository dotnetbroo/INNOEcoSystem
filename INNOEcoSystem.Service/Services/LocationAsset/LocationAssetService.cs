using AutoMapper;
using INNOEcoSystem.Data.IRepositories.LocationAssets;
using INNOEcoSystem.Domain.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using INNOEcoSystem.Service.Exceptions;
using INNOEcoSystem.Service.Commons.Helpers;
using INNOEcoSystem.Service.DTOs.LocationsAsset;
using INNOEcoSystem.Service.Interfaces.LocationAssets;
using INNOEcoSystem.Data.IRepositories.Locations;
using System.Threading.Channels;
using INNOEcoSystem.Domain.Entities.Assets;

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

    
        
    public async Task<LocationAssetForResultDto> CreateAsync(long Id,IFormFile formFile)
    {

        var location = await _locationRepository.SelectAll()
           .Where(c => c.Id == Id)
           .AsNoTracking()
           .FirstOrDefaultAsync();

        if (location is null  ||  location?.IsDeleted == true )
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
