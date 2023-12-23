using INNOEcoSystem.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace INNOEcoSystem.Service.DTOs.Users;

public class UserForCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public UserRole Role { get; set; }
    public long LocationId { get; set; }
    public IFormFile ProfilePicture { get; set; }
}
