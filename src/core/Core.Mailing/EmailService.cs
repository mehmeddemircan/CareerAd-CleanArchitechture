using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;


using System.Text;
using System.Threading.Tasks;

namespace Core.Mailing
{
    public class EmailService : IEmailService
    {
        private IConfiguration _configuration;
        private readonly MailSettings _mailSettings;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            _mailSettings = configuration.GetSection("MailSettings").Get<MailSettings>();
        }

        public async Task SendEmailAsync(Mail mail)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_mailSettings.SenderFullName, _mailSettings.SenderEmail));
            email.To.Add(new MailboxAddress(mail.ToFullName, mail.ToEmail));
            email.Subject = mail.Subject;

            var bodyBuilder = new BodyBuilder
            {
                TextBody = mail.TextBody,
                HtmlBody = mail.HtmlBody
            };

          

            email.Body = bodyBuilder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                await smtp.ConnectAsync(_mailSettings.Server, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_mailSettings.UserName, _mailSettings.Password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }
        }
    }
}
