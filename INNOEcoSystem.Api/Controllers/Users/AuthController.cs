using INNOEcoSystem.Models.Helpers;
using INNOEcoSystem.Service.DTOs.Logins;
using INNOEcoSystem.Service.Interfaces.Commons;
using INNOEcoSystem.Service.Services.Accaunts;
using Microsoft.AspNetCore.Mvc;

namespace INNOEcoSystem.Api.Controllers.Commons
{
    public class AuthController : BaseController
    {
        private readonly IAccountService accountService;

        public AuthController(IAccountService accountService, IAuthService authService)
        {
            this.accountService = accountService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login([FromBody] LoginDto loginDto)
            => Ok(await accountService.LoginAsync(loginDto));
    }
}
