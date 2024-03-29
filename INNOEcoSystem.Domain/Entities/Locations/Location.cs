﻿using INNOEcoSystem.Domain.Commons;
using INNOEcoSystem.Domain.Entities.Assets;

namespace INNOEcoSystem.Domain.Entities.Locations;

public class Location : Auditable
{
    public string Addres { get; set; }
    public decimal Latitude { get; set; }
    public decimal LongiTude { get; set; }

    public ICollection<LocationAsset> Assets { get; set; }
}
