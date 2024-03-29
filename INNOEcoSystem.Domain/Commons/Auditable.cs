﻿namespace INNOEcoSystem.Domain.Commons;

public class Auditable
{
    public long Id { get; set; }

    public bool IsDeleted { get; set; } = false;

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
