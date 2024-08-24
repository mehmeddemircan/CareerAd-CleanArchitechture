using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mailing
{
    public interface IEmailService
    {
        Task SendEmailAsync(Mail email);

        Task SendSuccessJobAdEmailAsync(string toEmail, string toFullName, string jobTitle, string companyName);
    }
}
