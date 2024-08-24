using QuickReserve.Domain.Entities.Auth;
using QuickReserve.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.JobAdApplications.Dtos
{
    public class CreatedJobAdApplicationDto
    {
        public int JobAdId { get; set; }
        public int UserId { get; set; }
      
        public string CvPdfPublicId { get; set; }
        public string CvPdfUrl { get; set; }
    }
}
