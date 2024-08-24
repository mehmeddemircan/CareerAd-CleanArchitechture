using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mailing.Templates
{
    public class FailedJobAdTemplate
    {
        public string FailJobAdEmailTemplate(string candidateName, string jobTitle, string companyName)
        {
            return $@"
                <html>
                    <body>
                        <h2>Dear {candidateName},</h2>
                        <p>Thank you for your interest in the <strong>{jobTitle}</strong> position at <strong>{companyName}</strong>.</p>
                        <p>After careful consideration, we regret to inform you that we have decided to move forward with other candidates for this role.</p>
                        <p>We encourage you to apply for future opportunities that match your qualifications. We appreciate your effort and wish you the best of luck in your job search.</p>
                        <p>Best regards,<br/>{companyName} HR Team</p>
                    </body>
                </html>";
        }
    }
}
