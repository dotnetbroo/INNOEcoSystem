using INNOEcoSystem.Service.DTOs.Logins;

namespace INNOEcoSystem.Service.Services.Accaunts;

public interface IAccountService
{
    public Task<string> LoginAsync(LoginDto loginDto);
}
