using AutoMapper;
using INNOEcoSystem.Data.IRepositories.LocationAssets;
using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Domain.Entities.Assets;
using INNOEcoSystem.Service.Commons.Extensions;
using INNOEcoSystem.Service.Commons.Helpers;
using INNOEcoSystem.Service.DTOs.LocationsAsset;
using INNOEcoSystem.Service.Exceptions;
using INNOEcoSystem.Service.Interfaces.LocationAssets;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace INNOEcoSystem.Service.Services.LocationAssets;

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
        long? locationId = HttpContextHelper.UserId;
        var location = await _locationAssetRepository.SelectAll()
        .Where(l => l.LocationId == l.LocationId)
        .AsNoTracking()
        .FirstOrDefaultAsync();

        if (location is not null)
            throw new INNOEcoSystemException(404, "Location is not found");

        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(formFile.FileName);
        var rootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "Media", "LocationPictures", "Locations", fileName);
        using (var stream = new FileStream(rootPath, FileMode.Create))
        {
            await formFile.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }

        var MappedLocationAsset = new LocationAsset()
        {
            LocationId = location.LocationId,
            Name = fileName,
            Path = Path.Combine("Media", "LocationPictures", "Locations", formFile.FileName),
            Extension = Path.GetExtension(formFile.FileName),
            Size = formFile.Length,
            Type = formFile.ContentType,
            CreatedAt = DateTime.UtcNow
        };

        var result = await _locationAssetRepository.InsertAsync(MappedLocationAsset);

        return _mapper.Map<LocationAssetForResultDto>(result);
    
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var LocationAsset = await _locationAssetRepository.SelectAll()
            .Where(ur => ur.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        if (LocationAsset is null)
            throw new INNOEcoSystemException(404, "Location is not found.");

        await _locationAssetRepository.DeleteAsync(id);
    
        return true;
    }

    public async Task<IEnumerable<LocationAssetForResultDto>> RetrieveAllAsync(long id,PaginationParams @params)
    {
        var LocationAssets = await _locationAssetRepository
            .SelectAll()
            .Where(l => l.LocationId == id)
            .Include(l => l.LocationId)
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<LocationAssetForResultDto>>(LocationAssets);

    }

    public async Task<LocationAssetForResultDto> RetrieveByIdAsync(long id)
    {
        var LocationAsset = await _locationAssetRepository.SelectAll()
            .Where(ur => ur.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (LocationAsset is null)
            throw new INNOEcoSystemException(404, "Location is not found.");

        var mapped = _mapper.Map<LocationAssetForResultDto>(LocationAsset);
     
        return mapped;
    
    }
}
