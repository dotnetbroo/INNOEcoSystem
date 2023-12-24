using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace INNOEcoSystem.Service.DTOs.Applications;

public class ApplicationForCreationDto
{
    [Required(ErrorMessage = "DepartmentId is required")]
    public long DepartmentId { get; set; }
    [Required(ErrorMessage = "UserId is required")]
    public long UserId { get; set; }
    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; }
    public decimal Balans { get; set; }
    public IFormFile Presentation { get; set; } = null;
}
