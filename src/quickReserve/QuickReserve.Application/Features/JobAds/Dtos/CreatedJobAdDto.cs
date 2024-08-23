using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.JobAds.Dtos
{
    public class CreatedJobAdDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string SalaryRange { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime Deadline { get; set; }
        public int CompanyId { get; set; }
    }
}
