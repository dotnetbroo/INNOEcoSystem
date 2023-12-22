using INNOEcoSystem.Domain.Entities.Applications;
using INNOEcoSystem.Domain.Enums;

namespace INNOEcoSystem.Service.DTOs.Users;

public class UserForResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string Salt { get; set; }
    public UserRole Role { get; set; }
    public string ProfilePicture { get; set; }
    public long LocationId { get; set; }

    public ICollection<Application> Applications { get; set; }
}
