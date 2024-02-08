using INNOEcoSystem.Service.DTOs.Logins;

namespace INNOEcoSystem.Service.Interfaces.Accounts;

public interface IAccountService
{
    public Task<string> LoginAsync(LoginDto loginDto);
}
