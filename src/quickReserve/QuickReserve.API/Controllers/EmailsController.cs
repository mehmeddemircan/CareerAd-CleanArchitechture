using Core.Mailing;
using Core.Results;
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

        [HttpPost]
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

        [HttpPost]
        public async Task<IActionResult> SendSuccessJobAdEmail(EmailTemplateRequest emailTemplateRequest)
        {
            if (string.IsNullOrEmpty(emailTemplateRequest.ToEmail))
            {
                return BadRequest(new ErrorResult("Geçersiz e-posta verisi."));
            }

            try
            {
                await _emailService.SendSuccessJobAdEmailAsync(emailTemplateRequest);
                return Ok(new SuccessResult("Başarıyla e-posta gönderildi."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"E-posta gönderimi sırasında bir hata oluştu: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SendReceivedJobAdEmail(EmailTemplateRequest emailTemplateRequest)
        {
            if (string.IsNullOrEmpty(emailTemplateRequest.ToEmail))
            {
                return BadRequest(new ErrorResult("Geçersiz e-posta verisi."));
            }

            try
            {
                await _emailService.SendReceivedJobAdEmailAsync(emailTemplateRequest);
                return Ok(new SuccessResult("Başvurunun alındığına dair e-posta başarıyla gönderildi."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"E-posta gönderimi sırasında bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<IActionResult> SendFailedJobAdEmail(EmailTemplateRequest emailTemplateRequest)
        {
            if (string.IsNullOrEmpty(emailTemplateRequest.ToEmail))
            {
                return BadRequest(new ErrorResult("Geçersiz e-posta verisi."));
            }

            try
            {
                await _emailService.SendFailedJobAdEmailAsync(emailTemplateRequest);
                return Ok(new SuccessResult("Başvurunun olumsuz sonuçlandığına dair e-posta başarıyla gönderildi.."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"E-posta gönderimi sırasında bir hata oluştu: {ex.Message}");
            }
        }
    }
}
