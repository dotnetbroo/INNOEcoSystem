using INNOEcoSystem.Domain.Entities.Locations;
using INNOEcoSystem.Service.DTOs.Locations;

namespace INNOEcoSystem.Service.DTOs.LocationsAsset;

public class LocationAssetForResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public string Extension { get; set; }
    public long Size { get; set; }
    public string Type { get; set; }
    public long LocationId { get; set; }
    public LocationForResultDto Location { get; set; }
}
