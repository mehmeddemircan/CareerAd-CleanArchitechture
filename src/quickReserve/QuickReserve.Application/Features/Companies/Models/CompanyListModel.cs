using Core.Persistence.Paging;
using QuickReserve.Application.Features.Companies.Dtos;
using QuickReserve.Application.Features.IndustryTypes.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.Companies.Models
{
    public class CompanyListModel : BasePageableModel
    {
        public IList<CompanyListDto> Items { get; set; }
    }
}
