using INNOEcoSystem.Api.Controllers.Commons;
using INNOEcoSystem.Models.Helpers;
using INNOEcoSystem.Service.Interfaces.Accaunts;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace INNOEcoSystem.Api.Controllers.Accounts
{
    public class SendCodesByEmailController : BaseController
    {
        private readonly IEmailService emailService;

        public SendCodesByEmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpPost("send-code")]

        public async Task<IActionResult> SendCodeByEmailAsync([EmailAddress, Required] string email)
            => Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = await this.emailService.SendCodeByEmailAsync(email)
            });


        [HttpPost("verify-code")]

        public IActionResult VerifyCode([EmailAddress, Required] string email, [Required] string code)
            => Ok(new Response
            {
                Code = 200,
                Message = "Success",
                Data = this.emailService.VerifyCode(email, code)
            });
    }
}
