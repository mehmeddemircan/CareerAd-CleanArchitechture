using QuickReserve.Application.Features.Users.Dtos;

namespace QuickReserve.Application.Features.Answers.Dtos
{
    public class AnswerListDto
    {
        public int Id { get; set; }
        public string Response { get; set; }
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

    }
}
