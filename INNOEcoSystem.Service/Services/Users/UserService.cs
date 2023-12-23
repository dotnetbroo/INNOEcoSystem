using AutoMapper;
using INNOEcoSystem.Data.IRepositories.Users;
using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Domain.Entities.Users;
using INNOEcoSystem.Service.Commons.Extensions;
using INNOEcoSystem.Service.Commons.Helpers;
using INNOEcoSystem.Service.DTOs.Users;
using INNOEcoSystem.Service.Exceptions;
using INNOEcoSystem.Service.Interfaces.User;
using INNOEcoSystem.Service.Services.Accaunts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace INNOEcoSystem.Service.Services.Users;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IConfiguration configuration;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository, IConfiguration configuration)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        this.configuration = configuration;
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
        mappedUser.Role = 0;

        var result = await _userRepository.InsertAsync(mappedUser);

        return this._mapper.Map<UserForResultDto>(result);
    }

    public async Task<bool> ChangePasswordAsync(string email, UserForChangePasswordDto dto)
    {
        var user = await _userRepository.SelectAsync(u => u.Email == email);
        if (user is null || !PasswordHelper.Verify(dto.OldPassword, user.Salt, user.Password))
            throw new INNOEcoSystemException(404, "User or Password is incorrect");
        else if (dto.NewPassword != dto.ConfirmPassword)
            throw new INNOEcoSystemException(400, "New password and confir password aren't equal");

        var hash = PasswordHelper.Hash(dto.ConfirmPassword);
        user.Salt = hash.Salt;
        user.Password = hash.Hash;
        var updated = await _userRepository.UpdateAsync(user);

        return true;
    }

    public async Task<bool> ForgetPasswordAsync(string PhoneNumber, string NewPassword, string ConfirmPassword)
    {
        var user = await _userRepository.SelectAsync(u => u.PhoneNumber == PhoneNumber);

        if (user is null)
            throw new INNOEcoSystemException(404, "User not found");

        if (NewPassword != ConfirmPassword)
            throw new INNOEcoSystemException(400, "New password and confirm password aren't equal");

        var hash = PasswordHelper.Hash(NewPassword);

        user.Salt = hash.Salt;
        user.Password = hash.Hash;

        var updated = _userRepository.UpdateAsync(user);

        return true;
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

        return true;
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

    public async Task<IEnumerable<UserForResultDto>> RetrieveAllDeletedUsersAsync(PaginationParams @params)
    {
        var users = await _userRepository.SelectAll()
            .Where(u => u.IsDeleted == true)
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
