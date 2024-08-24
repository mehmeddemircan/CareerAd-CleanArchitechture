using QuickReserve.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        //Şirket resmi 
        public string? LogoImage { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public int IndustryTypeId { get; set; }
        public virtual IndustryType IndustryType { get; set; }
        public virtual ICollection<JobAd> JobAds { get; set; }
    }
 
}
