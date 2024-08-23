using QuickReserve.Application.Features.JobAds.Dtos;

namespace QuickReserve.Application.Features.JobAdApplications.Dtos
{
    public class JobAdApplicationByIdDto
    {
        public int Id { get; set; }

        public int JobAdId { get; set; }

        public JobAdByIdDto JobAd { get; set; }
        public int UserId { get; set; }

        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

        public string CvPdfPublicId { get; set; }
        public string CvPdfUrl { get; set; }

    }
}
