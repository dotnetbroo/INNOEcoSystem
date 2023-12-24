using INNOEcoSystem.Service.DTOs.Users;

namespace INNOEcoSystem.Service.DTOs.Address;

public class AddressForResultDto
{
    public long Id { get; set; }
    public string Country { get; set; }
    public string Region { get; set; }
    public string District { get; set; }
    public bool IsDeleted { get; set; }

    public ICollection<UserForResultDto> Users { get; set; }
}
