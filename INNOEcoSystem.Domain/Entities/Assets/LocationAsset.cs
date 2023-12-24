using INNOEcoSystem.Domain.Commons;
using INNOEcoSystem.Domain.Entities.Locations;

namespace INNOEcoSystem.Domain.Entities.Assets;

public class LocationAsset : Auditable
{
    public string Path { get; set; }
    public long LacationId { get; set; }
    public Location Location { get; set; }

}
