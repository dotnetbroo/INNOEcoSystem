using INNOEcoSystem.Domain.Commons;

namespace INNOEcoSystem.Domain.Entities.Departments;

public class Category : Auditable
{
    public string Name { get; set; }
    public string Image { get; set; }
}
