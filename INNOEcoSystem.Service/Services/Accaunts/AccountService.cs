using INNOEcoSystem.Data.IRepositories;
using INNOEcoSystem.Domain.Entities.Users;
using INNOEcoSystem.Service.Commons.Helpers;
using INNOEcoSystem.Service.DTOs.Logins;
using INNOEcoSystem.Service.Exceptions;
using INNOEcoSystem.Service.Interfaces.Commons;

namespace INNOEcoSystem.Service.Services.Accaunts;

public class AccountService : IAccountService
{
    private readonly IAuthService authService;
    private readonly IRepository<User> userRepository;

    public AccountService(IRepository<User> userRepository, IAuthService authService)
    {
        this.authService = authService;
        this.userRepository = userRepository;
    }
    public async Task<string> LoginAsync(LoginDto loginDto)
    {
        var user = await this.userRepository.SelectAsync(x => x.PhoneNumber == loginDto.PhoneNumber);
        if (user is null)
            throw new INNOEcoSystemException(404, "Telefor raqam yoki parol xato kiritildi!");

        var hasherResult = PasswordHelper.Verify(loginDto.Password, user.Salt, user.Password);
        if (hasherResult == false)
            throw new INNOEcoSystemException(404, "Telefor raqam yoki parol xato kiritildi!");

        return authService.GenereteToken(user);
    }
}