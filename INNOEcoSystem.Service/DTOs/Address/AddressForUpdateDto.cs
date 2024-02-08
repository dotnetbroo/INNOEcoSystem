using System.ComponentModel.DataAnnotations;

namespace INNOEcoSystem.Service.DTOs.Address;

public class AddressForUpdateDto
{
    public string Country { get; set; }

    [Required(ErrorMessage = "Region is required")]
    public string Region { get; set; }
    [Required(ErrorMessage = "Region is required")]
    public string District { get; set; }
}
