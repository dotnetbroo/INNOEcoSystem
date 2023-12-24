using INNOEcoSystem.Domain.Commons;
using INNOEcoSystem.Domain.Entities.Applications;
using INNOEcoSystem.Domain.Entities.Locations;
using INNOEcoSystem.Domain.Enums;

namespace INNOEcoSystem.Domain.Entities.Users;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber {  get; set; }
    public string Salt {  get; set; }
    public UserRole Role { get; set; }
    public string ProfilePicture { get; set; }
    public long AddressId { get; set; }
    public Address UserAddress { get; set; }

    public ICollection<Application> Applications { get; set; }
}
