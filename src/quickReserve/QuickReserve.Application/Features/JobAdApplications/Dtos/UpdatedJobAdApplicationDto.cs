namespace QuickReserve.Application.Features.JobAdApplications.Dtos
{
    public class UpdatedJobAdApplicationDto
    {
        public int Id { get; set; }

        public int JobAdId { get; set; }
        public int UserId { get; set; }
        public string CvPdfPublicId { get; set; }
        public string CvPdfUrl { get; set; }
    }
}
