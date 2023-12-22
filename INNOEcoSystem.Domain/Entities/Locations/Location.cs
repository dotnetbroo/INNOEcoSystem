using INNOEcoSystem.Domain.Commons;
using INNOEcoSystem.Domain.Entities.Assets;

namespace INNOEcoSystem.Domain.Entities.Locations;

public class Location : Auditable
{
    public long LongiTude { get; set; }
    public long Latitude { get; set; }
    public string Addres { get; set; }

    public ICollection<LocationAsset> Assets { get; set; }
}
