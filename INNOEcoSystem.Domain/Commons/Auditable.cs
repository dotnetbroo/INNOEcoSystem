﻿namespace INNOEcoSystem.Domain.Commons;

public class Auditable
{
    public long Id { get; set; }
    public bool IsDeleed { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
