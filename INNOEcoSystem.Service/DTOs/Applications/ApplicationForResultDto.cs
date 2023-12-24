using INNOEcoSystem.Domain.Entities.Departments;
using INNOEcoSystem.Domain.Entities.Users;
using INNOEcoSystem.Domain.Enums;

namespace INNOEcoSystem.Service.DTOs.Applications;

public class ApplicationForResultDto
{
    public long Id { get; set; }
    public int Number { get; set; }
    public long DepartmentId { get; set; }

    public long UserId { get; set; }

    public string Description { get; set; }
    public string Presentation { get; set; }
    public decimal Balans { get; set; }
    public ApplicationStatus Status { get; set; }
}
