using System.ComponentModel.DataAnnotations;

namespace INNOEcoSystem.Service.DTOs.Locations;

public class LocationForCreationDto
{
    [Required(ErrorMessage = "LongiTude is required")]
    public decimal LongiTude { get; set; }
    [Required(ErrorMessage = "Latitude is required")]
    public decimal Latitude { get; set; }
    [Required(ErrorMessage = "Address is required")]
    public string Addres { get; set; }
}
