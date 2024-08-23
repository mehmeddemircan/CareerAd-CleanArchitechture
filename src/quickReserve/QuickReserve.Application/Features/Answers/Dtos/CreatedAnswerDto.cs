using QuickReserve.Domain.Entities.Auth;
using QuickReserve.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickReserve.Application.Features.Questions.Dtos;

namespace QuickReserve.Application.Features.Answers.Dtos
{
    public class CreatedAnswerDto
    {
        public string Response { get; set; }  
        public int QuestionId { get; set; } 
        public int UserId { get; set; }  
     
    }
}
