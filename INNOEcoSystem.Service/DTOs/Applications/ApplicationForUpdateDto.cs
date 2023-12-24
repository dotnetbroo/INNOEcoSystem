using INNOEcoSystem.Domain.Entities.Departments;
using INNOEcoSystem.Domain.Entities.Users;
using INNOEcoSystem.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace INNOEcoSystem.Service.DTOs.Applications;

public class ApplicationForUpdateDto
{
    public long DepartmentId { get; set; }

    public long UserId { get; set; }

    public string Description { get; set; }
    public decimal Balans { get; set; }
    public IFormFile Presentation { get; set; } = null;
}
