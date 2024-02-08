using INNOEcoSystem.Domain.Commons;
using INNOEcoSystem.Domain.Entities.Locations;

namespace INNOEcoSystem.Domain.Entities.Departments;

public class Department : Auditable
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Logo { get; set; }
    public string Website { get; set; }
    public string License { get; set; }
    public string Description { get; set; }
    public string PhoneNumber { get; set; }
    public string CallCenterNumer { get; set; }
    public long LocationId { get; set; }
    public Location Lacation { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; }

}
