using Microsoft.AspNetCore.Http;

namespace INNOEcoSystem.Service.DTOs.LocationsAsset;

public class LocationAssetForUpdateDto
{
    public long LocationId { get; set; }
    public IFormFile Path { get; set; }
}
