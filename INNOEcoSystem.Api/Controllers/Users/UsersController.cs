using INNOEcoSystem.Api.Controllers.Commons;
using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Models.Helpers;
using INNOEcoSystem.Service.DTOs.Users;
using INNOEcoSystem.Service.Interfaces.User;
using INNOEcoSystem.Service.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace INNOEcoSystem.Api.Controllers.Users
{
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] UserForCreationDto dto)
            => Ok(await _userService.AddAsync(dto));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await _userService.RetrieveAllAsync(@params));

        [HttpGet("retrieve-all-deleted-users")]
        public async Task<IActionResult> GetAllDeletedUsersAsync([FromQuery] PaginationParams @params)
            => Ok(await _userService.RetrieveAllDeletedUsersAsync(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
            => Ok(await this._userService.RetrieveByIdAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromForm] UserForUpdateDto dto)
            => Ok(await this._userService.ModifyAsync(id, dto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
            => Ok(await this._userService.RemoveAsync(id));

        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePasswordAsync([Required] string email, [FromForm] UserForChangePasswordDto dto)
            => Ok(await this._userService.ChangePasswordAsync(email, dto));

        [HttpPut("forget-password")]
        public async Task<IActionResult> ForgetPasswordAsync([Required] string PhoneNumber, [Required] string NewPassword, [Required] string ConfirmPassword)
        => Ok(await _userService.ForgetPasswordAsync(PhoneNumber, NewPassword, ConfirmPassword));
    }
}
