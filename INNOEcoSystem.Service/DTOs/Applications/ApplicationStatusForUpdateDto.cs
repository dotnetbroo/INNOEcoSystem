using INNOEcoSystem.Domain.Enums;

namespace INNOEcoSystem.Service.DTOs.Applications;

public class ApplicationStatusForUpdateDto
{
    public long Id { get; set; }
    public ApplicationStatus Status { get; set; }
}
