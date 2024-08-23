using Core.Persistence.Paging;
using QuickReserve.Application.Features.JobAdForms.Dtos;
using QuickReserve.Application.Features.JobAds.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.JobAdForms.Models
{
    public class JobAdFormListModel : BasePageableModel
    {
        public IList<JobAdFormListDto>  Items { get; set; }
    }
}
