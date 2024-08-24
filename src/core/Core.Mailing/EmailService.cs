using Core.Mailing.Templates;
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

        public async Task SendSuccessJobAdEmailAsync(EmailTemplateRequest emailTemplateRequest)
        {
            var template = new SuccessJobAdTemplate();
            string htmlBody = template.CreateJobAdEmailTemplate(emailTemplateRequest.JobTitle, emailTemplateRequest.CompanyName, emailTemplateRequest.ToFullName);

            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_mailSettings.SenderFullName, _mailSettings.SenderEmail));
            email.To.Add(new MailboxAddress(emailTemplateRequest.ToFullName, emailTemplateRequest.ToEmail));
            email.Subject = $"Congratulations on Your Success for the {emailTemplateRequest.JobTitle} Position!";

            var bodyBuilder = new BodyBuilder { HtmlBody = htmlBody };
            email.Body = bodyBuilder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                await smtp.ConnectAsync(_mailSettings.Server, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_mailSettings.UserName, _mailSettings.Password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }
        }

        public async Task SendReceivedJobAdEmailAsync(EmailTemplateRequest emailTemplateRequest)
        {
            var template = new ReceivedJobAdTemplate();
            string htmlBody = template.ReceviedJobAdTemplate(emailTemplateRequest.ToFullName, emailTemplateRequest.JobTitle, emailTemplateRequest.CompanyName);

            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_mailSettings.SenderFullName, _mailSettings.SenderEmail));
            email.To.Add(new MailboxAddress(emailTemplateRequest.ToFullName, emailTemplateRequest.ToEmail));
            email.Subject = $"Your Application for the {emailTemplateRequest.JobTitle} Position Has Been Received";

            var bodyBuilder = new BodyBuilder { HtmlBody = htmlBody };
            email.Body = bodyBuilder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                await smtp.ConnectAsync(_mailSettings.Server, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_mailSettings.UserName, _mailSettings.Password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }
        }

        public async Task SendFailedJobAdEmailAsync(string toEmail, string toFullName, string jobTitle, string companyName)
        {
            var template = new FailedJobAdTemplate();
            string htmlBody = template.FailJobAdEmailTemplate(toFullName, jobTitle, companyName);

            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_mailSettings.SenderFullName, _mailSettings.SenderEmail));
            email.To.Add(new MailboxAddress(toFullName, toEmail));
            email.Subject = $"Your Application for the {jobTitle} Position at {companyName}";

            var bodyBuilder = new BodyBuilder { HtmlBody = htmlBody };
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
