using Microsoft.AspNetCore.Http;

namespace INNOEcoSystem.Service.DTOs.Categories;

public class CategoryImageForUpdateDto
{
    public IFormFile Image { get; set; } = null;
}
