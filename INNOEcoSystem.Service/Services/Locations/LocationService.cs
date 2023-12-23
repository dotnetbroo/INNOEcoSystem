using AutoMapper;
using INNOEcoSystem.Data.IRepositories.Locations;
using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Domain.Entities.Locations;
using INNOEcoSystem.Service.Commons.Extensions;
using INNOEcoSystem.Service.DTOs.Locations;
using INNOEcoSystem.Service.Exceptions;
using INNOEcoSystem.Service.Interfaces.Location;
using Microsoft.EntityFrameworkCore;

namespace INNOEcoSystem.Service.Services.Locations;

public class LocationService : ILocationService
{
    private readonly IMapper _mapper;
    private readonly ILocationRepository _locationRepository;

    public LocationService(
        IMapper mapper,
        ILocationRepository locationRepository)
    {
        _mapper = mapper;
        _locationRepository = locationRepository;
    }
    LocationService(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public void SaveLocation(Location location)
    {
        _locationRepository.InsertAsync(location);
    }

    public IEnumerable<Location> GetLocations()
    {
        return _locationRepository.SelectAll();
    }
    public async Task<LocationForResultDto> CreateAsync(LocationForCreationDto dto)
    {
        var existingLocation = await _locationRepository.SelectAll()
            .Where(l => l.Addres.ToLower() == dto.Addres.ToLower())
            .FirstOrDefaultAsync();

        if (existingLocation is not null)
            throw new INNOEcoSystemException(400, "Location with the same address already exists.");

        var longtitude = await _locationRepository
            .SelectAll()
            .Where(l => l.LongiTude == dto.LongiTude && l.Latitude == dto.Latitude)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (longtitude is not null)
            throw new INNOEcoSystemException(400, "Longtitude is already exists.");

        var location = _mapper.Map<Location>(dto);
        location.CreatedAt = DateTime.UtcNow;
        var result = await _locationRepository.InsertAsync(location);

        return _mapper.Map<LocationForResultDto>(result);
    }

    public async Task<LocationForResultDto> ModifyAsync(long id, LocationForUpdateDto dto)
    {
        var location = await _locationRepository.SelectAll()
            .Where(l => l.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (location is null)
            throw new INNOEcoSystemException(404, "Location is not found.");

        var longtitude = await _locationRepository
            .SelectAll()
            .Where(l => l.LongiTude == dto.LongiTude && l.Latitude == dto.Latitude)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (longtitude is not null)
            throw new INNOEcoSystemException(400, "Longtitude is already exists.");


        var mapped = _mapper.Map(dto, location);
        mapped.UpdatedAt = DateTime.UtcNow;

        await _locationRepository.UpdateAsync(mapped);

        return _mapper.Map<LocationForResultDto>(mapped);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var location = await _locationRepository.SelectAll()
            .Where(l => l.Id == id)
            .FirstOrDefaultAsync();

        if (location is null)
            throw new INNOEcoSystemException(404, "Location is not found.");


        return await _locationRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<LocationForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var locations = await _locationRepository
            .SelectAll()
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<LocationForResultDto>>(locations);
    }

    public async Task<LocationForResultDto> RetrieveByIdAsync(long id)
    {
        var location = await _locationRepository.SelectAll()
            .Where(l => l.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (location is null)
            throw new INNOEcoSystemException(404, "Location is not found.");

        return _mapper.Map<LocationForResultDto>(location);
    }
}
