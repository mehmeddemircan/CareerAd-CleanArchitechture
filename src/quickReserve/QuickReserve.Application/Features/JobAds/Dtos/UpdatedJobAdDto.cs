namespace QuickReserve.Application.Features.JobAds.Dtos
{
    public class UpdatedJobAdDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string SalaryRange { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime Deadline { get; set; }
        public int CompanyId { get; set; }
    }
}
