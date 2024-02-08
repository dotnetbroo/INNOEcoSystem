using Microsoft.AspNetCore.Http;

namespace INNOEcoSystem.Service.DTOs.DepartmentAssets;

public class DepartmentAssetForCreationDto
{
    public IFormFile formFile { get; set; }
}
