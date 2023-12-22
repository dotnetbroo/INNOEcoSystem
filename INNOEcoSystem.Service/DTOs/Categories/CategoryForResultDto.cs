using Microsoft.AspNetCore.Http;

namespace INNOEcoSystem.Service.DTOs.Categories;

public class CategoryForResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public IFormFile Image { get; set; }
}
