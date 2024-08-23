using QuickReserve.Application.Features.JobAds.Dtos;

namespace QuickReserve.Application.Features.JobAdForms.Dtos
{
    public class JobAdFormListDto
    {
        public int Id { get; set; }
        public int JobAdId { get; set; }

        public JobAdByIdDto JobAd { get; set; }

    }
}
