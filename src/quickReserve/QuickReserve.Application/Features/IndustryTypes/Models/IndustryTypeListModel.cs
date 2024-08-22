using Core.Persistence.Paging;
using QuickReserve.Application.Features.IndustryTypes.Dtos;
using QuickReserve.Application.Features.OperationClaims.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.IndustryTypes.Models
{
    public class IndustryTypeListModel : BasePageableModel
    {
        public IList<IndustryTypeListDto> Items { get; set; }
    }
}
