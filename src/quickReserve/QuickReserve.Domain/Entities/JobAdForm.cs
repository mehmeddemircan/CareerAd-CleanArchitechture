using QuickReserve.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Domain.Entities
{
    public class JobAdForm : BaseEntity
    {  
        public int JobAdId { get; set; }
        public virtual JobAd JobAd { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
