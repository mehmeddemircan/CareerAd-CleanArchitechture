namespace QuickReserve.Application.Features.Answers.Dtos
{
    public class UpdatedAnswerDto
    {
        public int Id { get; set; }
        public string Response { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }

    }
}
