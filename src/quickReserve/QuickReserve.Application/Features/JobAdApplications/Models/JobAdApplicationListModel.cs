using Core.Persistence.Paging;
using QuickReserve.Application.Features.JobAdApplications.Dtos;
using QuickReserve.Application.Features.JobAds.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.JobAdApplications.Models
{
    public class JobAdApplicationListModel : BasePageableModel
    {
        public IList<JobAdApplicationListDto> Items { get; set; }
    }
}
