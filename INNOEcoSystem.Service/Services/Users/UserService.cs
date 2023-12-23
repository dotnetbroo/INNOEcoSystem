using AutoMapper;
using INNOEcoSystem.Data.IRepositories;
using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Domain.Entities.Users;
using INNOEcoSystem.Service.Commons.Extensions;
using INNOEcoSystem.Service.Commons.Helpers;
using INNOEcoSystem.Service.DTOs.Users;
using INNOEcoSystem.Service.Exceptions;
using INNOEcoSystem.Service.Interfaces.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;

namespace INNOEcoSystem.Service.Services.Users;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IRepository<User> _userRepository;

    public UserService(IMapper mapper, IRepository<User> userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<UserForResultDto> AddAsync(UserForCreationDto dto)
    {
        var user = await _userRepository.SelectAsync(u => u.PhoneNumber == dto.PhoneNumber);
        if (user is not null)
            throw new INNOEcoSystemException(403, "User is already exists");

        var imageFileName = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.ProfilePicture.FileName);
        var imageRootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "Media", "UserProfilePictures", "Images", imageFileName);
        using (var stream = new FileStream(imageRootPath, FileMode.Create))
        {
            await dto.ProfilePicture.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }
        string imageResult = Path.Combine("Media", "UserProfilePictures", "Images", imageFileName);

        var hasherResult = PasswordHelper.Hash(dto.Password);
        var mappedUser = _mapper.Map<User>(dto);

        mappedUser.CreatedAt = DateTime.UtcNow;
        mappedUser.Salt = hasherResult.Salt;
        mappedUser.Password = hasherResult.Hash;
        mappedUser.ProfilePicture = imageResult;

        var result = await _userRepository.InsertAsync(mappedUser);

        return this._mapper.Map<UserForResultDto>(result);
    }

    public async Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto)
    {
        var user = await _userRepository.SelectAsync(u => u.Id == id);
        if (user is null)
            throw new INNOEcoSystemException(404, "User is not found");

        var imageFullPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, user.ProfilePicture);

        if (File.Exists(imageFullPath))
            File.Delete(imageFullPath);

        var imageFileName = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.ProfilePicture.FileName);
        var imageRootPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, "Media", "UserProfilePictures", "Images", imageFileName);
        using (var stream = new FileStream(imageRootPath, FileMode.Create))
        {
            await dto.ProfilePicture.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }
        string imageResult = Path.Combine("Media", "UserProfilePictures", "Images", imageFileName);

        var mappedUser = _mapper.Map(dto, user);
        mappedUser.UpdatedAt = DateTime.UtcNow;

        mappedUser.ProfilePicture = imageResult;

        return _mapper.Map<UserForResultDto>(mappedUser);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var user = await _userRepository.SelectAsync(u => u.Id == id);
        if (user is null)
            throw new INNOEcoSystemException(404, "User is not found");

        var imageFullPath = Path.Combine(WebHostEnviromentHelper.WebRootPath, user.ProfilePicture);

        if (File.Exists(imageFullPath))
            File.Delete(imageFullPath);

        user.IsDeleted = true;
        await _userRepository.UpdateAsync(user);

        return true ;
    }

    public async Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var users = await _userRepository.SelectAll()
            .Where(u => u.IsDeleted == false)
            .Include(ua => ua.Applications)
            .AsNoTracking()
            .ToPagedList(@params)
            .ToListAsync();

        return _mapper.Map<IEnumerable<UserForResultDto>>(users);
    }


    public async Task<UserForResultDto> RetrieveByIdAsync(long id)
    {
        var users = await _userRepository.SelectAll()
            .Where(u => u.Id == id && u.IsDeleted == false)
            .Include(ua => ua.Applications)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (users is null)
            throw new INNOEcoSystemException(404, "User is not found");

        return _mapper.Map<UserForResultDto>(users);
    }
}
