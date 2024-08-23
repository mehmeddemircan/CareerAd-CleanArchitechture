using Core.Persistence.Paging;
using QuickReserve.Application.Features.Answers.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.Answers.Models
{
    public class AnswerListModel : BasePageableModel
    {
        public IList<AnswerListDto> Items { get; set; }
    }
}
