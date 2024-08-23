using QuickReserve.Domain.Common;
using QuickReserve.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Domain.Entities
{
    public class JobAdApplication : BaseEntity
    { 
   
        public int JobAdId { get; set; }
        public virtual JobAd JobAd { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        // CV (Öz gecmiş kısmı ) 
        public string CvPdfPublicId { get; set; }
        public string CvPdfUrl { get; set; }
    }
}
