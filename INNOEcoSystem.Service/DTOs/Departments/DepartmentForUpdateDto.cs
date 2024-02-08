using INNOEcoSystem.Service.Commons.Attributes;
using System.ComponentModel.DataAnnotations;

namespace INNOEcoSystem.Service.DTOs.Departments;

public class DepartmentForUpdateDto
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Email is required")]
    [EmailAttribute]
    public string Email { get; set; }
    [Required(ErrorMessage = "Website is required")]
    public string Website { get; set; }
    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; }
    [Required(ErrorMessage = "Phone number is required")]
    public string PhoneNumber { get; set; }
    [Required(ErrorMessage = "Call center number is required")]
    public string CallCenterNumer { get; set; }
    [Required(ErrorMessage = "LocationId is required")]
    public long LocationId { get; set; }
    [Required(ErrorMessage = "CategoryId is required")]
    public long CategoryId { get; set; }
}
