﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mailing
{
    public interface IEmailService
    {
        Task SendEmailAsync(Mail email);
        Task SendSuccessJobAdEmailAsync(EmailTemplateRequest emailRequest);
        Task SendReceivedJobAdEmailAsync(EmailTemplateRequest emailRequest);
        Task SendFailedJobAdEmailAsync(EmailTemplateRequest emailRequest);
    }
}
