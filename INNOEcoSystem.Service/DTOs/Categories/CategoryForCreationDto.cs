using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace INNOEcoSystem.Service.DTOs.Categories;

public class CategoryForCreationDto
{
    [Required(ErrorMessage = "Category name is required")]
    public string Name { get; set; }
    public IFormFile Image { get; set; } = null;
}
