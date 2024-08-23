using Core.Persistence.Paging;
using QuickReserve.Application.Features.JobAds.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.JobAds.Models
{
    public class JobAdListModel : BasePageableModel
    {
        public IList<JobAdListDto>  Items { get; set; }
    }
}
