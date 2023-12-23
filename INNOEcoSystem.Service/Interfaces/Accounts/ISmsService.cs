using INNOEcoSystem.Service.Services.Accaunts.Models;

namespace INNOEcoSystem.Service.Interfaces.Accounts;

public interface ISmsService
{
    public Task<bool> SendAsync(Sms message);
    public Task<string> GenerateTokenAsync();
}
