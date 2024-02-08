using INNOEcoSystem.Service.Services.Accaunts.Models;

namespace INNOEcoSystem.Service.Interfaces.Accaunts;

public interface IEmailService
{
    public Task SendMessageAsync(Message message);

    public Task<bool> SendCodeByEmailAsync(string email);

    public bool VerifyCode(string email, string code);
}
