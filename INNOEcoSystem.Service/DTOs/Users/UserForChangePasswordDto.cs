﻿using INNOEcoSystem.Service.Commons.Attributes;
using System.ComponentModel.DataAnnotations;

namespace INNOEcoSystem.Service.DTOs.Users;

public class UserForChangePasswordDto
{
    [Required(ErrorMessage = "Old password must not be null or empty!")]
    [StrongPasswordAttribute]
    public string OldPassword { get; set; }

    [Required(ErrorMessage = "New password must not be null or empty!")]
    [StrongPasswordAttribute]
    public string NewPassword { get; set; }

    [Required(ErrorMessage = "Confirming password must not be null or empty!")]
    [StrongPasswordAttribute]
    public string ConfirmPassword { get; set; }
}
