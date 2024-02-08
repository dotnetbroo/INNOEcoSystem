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



    public async Task<LocationAssetForResultDto> CreateAsync(LocationAssetForCreationDto dto)
    {
        var location = await _locationRepository.SelectAll()
             .Where(e => e.Id == dto.LacationId)
             .FirstOrDefaultAsync();

        if (location is null)
            throw new INNOEcoSystemException(404, "Event is not found");


        var WwwRootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "Media", "LocationAssets");
        var assetsFolderPath = Path.Combine(WwwRootPath, "Media");
        var ImagesFolderPath = Path.Combine(assetsFolderPath, "LocationAssets");

        if (!Directory.Exists(assetsFolderPath))
        {
            Directory.CreateDirectory(assetsFolderPath);
        }

        if (!Directory.Exists(ImagesFolderPath))
        {
            Directory.CreateDirectory(ImagesFolderPath);
        }
        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.Path.FileName);

        var fullPath = Path.Combine(WwwRootPath, fileName);

        using (var stream = File.OpenWrite(fullPath))
        {
            await dto.Path.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }

        string resultImage = Path.Combine("Media", "LocationAssets", fileName);

        var mappedAsset = new LocationAsset
        {
            LacationId = dto.LacationId,
        };
        mappedAsset.CreatedAt = DateTime.UtcNow;
        mappedAsset.Path = resultImage;

        var result = await _locationAssetRepository.InsertAsync(mappedAsset);

        return _mapper.Map<LocationAssetForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var location = await _locationAssetRepository.SelectAsync(l => l.Id == id && l.IsDeleted == false);
        if (location is null)
            throw new INNOEcoSystemException(404, "Location Asset is not found");

        var locationn = await _locationRepository.SelectAsync(l => l.Id == location.LacationId && l.IsDeleted == false);
        if (locationn is null)
            throw new INNOEcoSystemException(404, "Location is not found");

        var imageFullPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, location.Path);

        if (File.Exists(imageFullPath))
            File.Delete(imageFullPath);

        location.IsDeleted = true;
        await _locationAssetRepository.UpdateAsync(location);

        return true;
    }

    public async Task<LocationAssetForResultDto> ModifyAsync(long id, LocationAssetForUpdateDto dto)
    {
        var locationAsset = await _locationAssetRepository.SelectAsync(l => l.Id == id && l.IsDeleted == false);
        if (locationAsset is null)
            throw new INNOEcoSystemException(404, "Location asset is not found");

        var imageFullPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, locationAsset.Path);

        if (File.Exists(imageFullPath))
            File.Delete(imageFullPath);

        var imageFileName = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.Path.FileName);
        var imageRootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "Media", "Locations", "Assets", imageFileName);
        using (var stream = new FileStream(imageRootPath, FileMode.Create))
        {
            await dto.Path.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }
        string imageResult = Path.Combine("Media", "Locations", "Assets", imageFileName);

        var mappedAsset = _mapper.Map(dto, locationAsset);
        mappedAsset.UpdatedAt = DateTime.UtcNow;
        mappedAsset.Path = imageResult;

        return _mapper.Map<LocationAssetForResultDto>(mappedAsset);
    }

    public async Task<IEnumerable<LocationAssetForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {

        var LocationAssets = await _locationAssetRepository.SelectAll()
            .Where(l => l.IsDeleted == false)
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<LocationAssetForResultDto>>(LocationAssets);

    }

    public async Task<LocationAssetForResultDto> RetrieveByIdAsync(long id)
    {
        var locationAsset = await _locationRepository.SelectAll()
            .Where(l => l.Id == id && l.IsDeleted == false)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (locationAsset is null || locationAsset?.IsDeleted == true)
            throw new INNOEcoSystemException(404, "Location is not found");

        return _mapper.Map<LocationAssetForResultDto>(locationAsset);

    }
}
