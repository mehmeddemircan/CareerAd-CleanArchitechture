using QuickReserve.Domain.Common;

namespace QuickReserve.Domain.Entities
{
    public class JobAd : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string SalaryRange { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime Deadline { get; set; }
        public int CompanyId { get; set; }
        public virtual  Company Company { get; set; }

        public virtual JobAdForm JobAdForm { get; set; }
        public virtual ICollection<JobAdApplication> JobAdApplications { get; set; }
    }
 
}
