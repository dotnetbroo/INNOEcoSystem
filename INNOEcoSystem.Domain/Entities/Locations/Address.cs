using INNOEcoSystem.Domain.Commons;
using INNOEcoSystem.Domain.Entities.Users;

namespace INNOEcoSystem.Domain.Entities.Locations;

public class Address : Auditable
{
    public string Country { get; set; }
    public string Region { get; set; }
    public string District { get; set; }

    public ICollection<User> Users { get; set; }
}
