using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mailing.Templates
{
    public class SuccessJobAdTemplate
    {
        public string CreateJobAdEmailTemplate(string jobTitle, string companyName, string candidateName)
        {
            return $@"
                <html>
                    <body>
                        <h2>Congratulations, {candidateName}!</h2>
                        <p>We are pleased to inform you that your application for the <strong>{jobTitle}</strong> position at <strong>{companyName}</strong> has been successful.</p>
                        <p>We look forward to having you on our team.</p>
                        <p>Best regards,<br/>{companyName} HR Team</p>
                    </body>
                </html>";
        }
    }
}

