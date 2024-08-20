using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } 
        public bool IsActive { get; set; } 
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }

        public BaseEntity()
        {
            CreatedTime = DateTime.UtcNow;
            IsDeleted = false;
            IsActive = true;

        }

        public BaseEntity(int id) : this()
        {
            Id = id;
        }
    }
}
