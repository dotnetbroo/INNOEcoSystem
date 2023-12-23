using INNOEcoSystem.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace INNOEcoSystem.Service.DTOs.Users;

public class UserForUpdateDto
{
    [Required(ErrorMessage = "FirstName is required")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "LastName is required")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "Phone number is required")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Address is required")]
    public long AddressId { get; set; }

    public IFormFile ProfilePicture { get; set; }
}
