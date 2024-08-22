using QuickReserve.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Domain.Entities
{
    public class IndustryType : BaseEntity
    {
        public string Name { get; set; }

    
        //public virtual ICollection<Company> Companies { get; set; }
    }
}
