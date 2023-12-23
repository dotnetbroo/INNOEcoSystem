using INNOEcoSystem.Service.DTOs.LocationsAsset;

namespace INNOEcoSystem.Service.DTOs.Locations;

public  class LocationForResultDto
{
    public long Id { get; set; }

    public string Addres { get; set; }
    public decimal LongiTude { get; set; }
    public decimal Latitude { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public long LacationId { get; set; }
    public ICollection<LocationAssetForResultDto> LacationAssets { get; set; }
}
