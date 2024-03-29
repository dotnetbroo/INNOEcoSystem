﻿using INNOEcoSystem.Domain.Commons;
using INNOEcoSystem.Domain.Entities.Departments;
using INNOEcoSystem.Domain.Entities.Users;
using INNOEcoSystem.Domain.Enums;

namespace INNOEcoSystem.Domain.Entities.Applications;

public class Application : Auditable
{
    public int Number { get; set; }
    public long DepartmentId { get; set; }
    public Department Department { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }

    public string Description { get; set; }
    public string Presentation { get; set; }
    public decimal Balans { get; set; }
    public ApplicationStatus Status { get; set; }
}
