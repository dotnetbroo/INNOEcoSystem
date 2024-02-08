using Microsoft.AspNetCore.Http;

namespace INNOEcoSystem.Service.DTOs.Users;

public class UserImageUpdateDto
{
    public IFormFile ProfilePicture { get; set; } = null;
}
