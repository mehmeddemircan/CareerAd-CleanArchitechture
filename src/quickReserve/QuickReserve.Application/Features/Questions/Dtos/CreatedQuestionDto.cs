using QuickReserve.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.Questions.Dtos
{
    public class CreatedQuestionDto
    {
        public string Text { get; set; }  // Sorunun metni
        public int JobAdFormId { get; set; }
    }
}
