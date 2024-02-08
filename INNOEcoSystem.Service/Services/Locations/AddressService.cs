using AutoMapper;
using INNOEcoSystem.Data.IRepositories.Users;
using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Domain.Entities.Locations;
using INNOEcoSystem.Service.Commons.Extensions;
using INNOEcoSystem.Service.DTOs.Address;
using INNOEcoSystem.Service.Exceptions;
using INNOEcoSystem.Service.Interfaces.Locations;
using Microsoft.EntityFrameworkCore;

namespace INNOEcoSystem.Service.Services.Locations;

public class AddressService : IAddressService
{
    private readonly IMapper _mapper;
    private readonly IAddressRepository _addressRepository;

    public AddressService(IAddressRepository addressRepository, IMapper mapper)
    {
        _addressRepository = addressRepository;
        _mapper = mapper;
    }

    public async Task<AddressForResultDto> CreateAsync(AddressForCreationDto dto)
    {
        var userAddress = _mapper.Map<Address>(dto);
        userAddress.CreatedAt = DateTime.UtcNow;
        var result = await _addressRepository.InsertAsync(userAddress);

        return _mapper.Map<AddressForResultDto>(result);
    }

    public async Task<AddressForResultDto> ModifyAsync(long id, AddressForUpdateDto dto)
    {
        var userAddress = await _addressRepository.SelectAsync(u => u.Id == id && u.IsDeleted == false);
        if (userAddress is null)
            throw new INNOEcoSystemException(404, "Address is not found.");

        _mapper.Map(dto, userAddress);
        userAddress.UpdatedAt = DateTime.UtcNow;

        return _mapper.Map<AddressForResultDto>(userAddress);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var address = await _addressRepository.SelectAsync(u => u.Id == id);
        if (address is null)
            throw new INNOEcoSystemException(404, "Address is not found");

        address.IsDeleted = true;
        await _addressRepository.UpdateAsync(address);

        return true;
    }

    public async Task<IEnumerable<AddressForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var addresses = await _addressRepository.SelectAll()
            .Where(u => u.IsDeleted == false)
            .Include(u => u.Users)
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<AddressForResultDto>>(addresses);
    }


    public async Task<IEnumerable<AddressForResultDto>> RetrieveAllDeletedUsersAddressAsync(PaginationParams @params)
    {
        var addresses = await _addressRepository.SelectAll()
            .Where(u => u.IsDeleted == true)
            .Include(u => u.Users)
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<AddressForResultDto>>(addresses);
    }



    public async Task<AddressForResultDto> RetrieveByIdAsync(long id)
    {
        var address = await _addressRepository.SelectAll()
            .Where(u => u.Id == id && u.IsDeleted == false)
            .Include(u => u.Users)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (address is null)
            throw new INNOEcoSystemException(404, "Address is not found");

        return _mapper.Map<AddressForResultDto>(address);
    }
}
