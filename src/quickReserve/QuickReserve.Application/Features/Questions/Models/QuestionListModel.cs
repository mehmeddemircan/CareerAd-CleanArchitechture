using Core.Persistence.Paging;
using QuickReserve.Application.Features.Questions.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.Questions.Models
{
    public class QuestionListModel : BasePageableModel
    {
        public IList<QuestionListDto> Items { get; set; }
    }
}
