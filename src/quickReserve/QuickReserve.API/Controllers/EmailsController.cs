using Core.Mailing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuickReserve.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailsController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] Mail mail)
        {
            if (mail == null || string.IsNullOrEmpty(mail.ToEmail))
            {
                return BadRequest("Geçersiz e-posta verisi.");
            }

            try
            {
                await _emailService.SendEmailAsync(mail);
                return Ok("E-posta başarıyla gönderildi.");
            }
            catch (Exception ex)
            {
              
                return StatusCode(500, $"E-posta gönderimi sırasında bir hata oluştu: {ex.Message}");
            }
        }
    }
}
