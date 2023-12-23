using INNOEcoSystem.Domain.Entities.Users;
using INNOEcoSystem.Service.Interfaces.Commons;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace INNOEcoSystem.Service.Services.Commons;


public class AuthService : IAuthService
{
    private readonly IConfigurationSection configuration;
    public AuthService(IConfiguration configuration)
    {
        this.configuration = configuration.GetSection("Jwt");
    }
    public string GenereteToken(User user)
    {
        var claims = new[]
        {

            new Claim("Id", user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.FirstName+ " " + user.LastName),
            new Claim("PhoneNumber", user.PhoneNumber),
            new Claim("Email", user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecretKey"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(configuration["Issuer"], configuration["Audience"], claims,
            expires: DateTime.Now.AddMinutes(double.Parse(configuration["Lifetime"])),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }

}
