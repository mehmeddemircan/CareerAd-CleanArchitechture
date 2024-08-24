using QuickReserve.Application.Features.JobAdForms.Dtos;

namespace QuickReserve.Application.Features.Questions.Dtos
{
    public class QuestionListDto
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public string QuestionType { get; set; }
        public int JobAdFormId { get; set; }

        public JobAdFormByIdDto JobAdForm { get; set; }
    }
}
