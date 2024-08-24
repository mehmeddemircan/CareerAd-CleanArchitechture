using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mailing
{
    public class EmailTemplateRequest
    {
        public string ToEmail { get; set; }
        public string ToFullName { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }

       
    }
}
