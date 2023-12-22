using Microsoft.AspNetCore.Http;

namespace INNOEcoSystem.Service.DTOs.Categories;

public class CategoryForCreationDto
{
    public string Name { get; set; }
    public IFormFile Image { get; set; }
}
