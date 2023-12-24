using INNOEcoSystem.Domain.Commons;
using INNOEcoSystem.Domain.Entities.Locations;

namespace INNOEcoSystem.Domain.Entities.Assets;

public class LocationAsset : Auditable
{
    public string Name { get; set; }
    public string Path { get; set; }
    public string Extension { get; set; }
    public long Size { get; set; }
    public string Type { get; set; }
    public long LacationId { get; set; }

    public Location Location { get; set; }

}
