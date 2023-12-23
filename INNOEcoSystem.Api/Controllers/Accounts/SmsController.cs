using INNOEcoSystem.Api.Controllers.Commons;
using INNOEcoSystem.Models.Helpers;
using INNOEcoSystem.Service.Interfaces.Accounts;
using INNOEcoSystem.Service.Services.Accaunts.Models;
using Microsoft.AspNetCore.Mvc;

namespace INNOEcoSystem.Api.Controllers.Accounts
{
    public class SmsController : BaseController
    {
        private readonly ISmsService smsService;

        public SmsController(ISmsService smsService)
        {
            this.smsService = smsService;
        }

        [HttpGet("generete-token")]
        public async Task<IActionResult> GenereteToken()
            => Ok(await smsService.GenerateTokenAsync());

/*        [HttpPost]
        public async Task<IActionResult> SendMessageAsync(Sms message)
        => Ok(await this.smsService.SendAsync(message));*/
    }
}
