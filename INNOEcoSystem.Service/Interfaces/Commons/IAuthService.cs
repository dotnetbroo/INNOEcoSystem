namespace INNOEcoSystem.Service.Interfaces.Commons;

public interface IAuthService
{
    public string GenereteToken(INNOEcoSystem.Domain.Entities.Users.User user);
}
