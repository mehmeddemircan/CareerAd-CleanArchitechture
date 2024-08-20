using QuickReserve.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Domain.Entities.Auth
{
    public class OperationClaim : BaseEntity
    {
        public string Name { get; set; }

        public OperationClaim()
        {
        }

        public OperationClaim(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
