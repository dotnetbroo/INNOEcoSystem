using INNOEcoSystem.Service.DTOs.LocationsAsset;

namespace INNOEcoSystem.Service.DTOs.Locations;

public  class LocationForResultDto
{
    public long Id { get; set; }

    public string Addres { get; set; }
    public decimal LongiTude { get; set; }
    public decimal Latitude { get; set; }
    public ICollection<LocationAssetForResultDto> LacationAssets { get; set; }
}
