using Microsoft.AspNetCore.Http;

namespace INNOEcoSystem.Service.DTOs.LocationsAsset;

public class LocationAssetForCreationDto
{
    public long LacationId { get; set; }
    public IFormFile Path {  get; set; }
}
