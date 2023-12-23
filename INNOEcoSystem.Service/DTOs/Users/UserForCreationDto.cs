using INNOEcoSystem.Service.Commons.Attributes;
using INNOEcoSystem.Service.Commons.Helpers;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace INNOEcoSystem.Service.DTOs.Users;

public class UserForCreationDto
{
    [Required(ErrorMessage = "FirstName is required")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "LastName is required")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAttribute]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MinLength(8), MaxLength(32)]
    [StrongPasswordAttribute]
    public string Password { get; set; }
    [Required(ErrorMessage = "Phone number is required")]
    [PhoneNumberAttribute]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Address is required")]
    public long AddressId { get; set; }
    [Required(ErrorMessage = "Profile picture is required")]
    public IFormFile ProfilePicture { get; set; }
}
