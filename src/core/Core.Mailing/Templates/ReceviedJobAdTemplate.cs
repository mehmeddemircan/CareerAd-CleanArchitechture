using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mailing.Templates
{
    public class ReceivedJobAdTemplate
    {
        public string ReceviedJobAdTemplate(string candidateName, string jobTitle, string companyName)
        {
            return $@"
                <html>
                    <body>
                        <h2>Dear {candidateName},</h2>
                        <p>Thank you for applying for the <strong>{jobTitle}</strong> position at <strong>{companyName}</strong>.</p>
                        <p>Your application has been successfully received. Our team will review your qualifications and get back to you shortly.</p>
                        <p>Best regards,<br/>{companyName} HR Team</p>
                    </body>
                </html>";
        }
    }
}
