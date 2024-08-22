using Core.Persistence.Repositories;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities;
using QuickReserve.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Persistence.Repositories
{
    public class IndustryTypeRepository : EfBaseRepository<IndustryType, BaseDbContext>, IIndustryTypeRepository
    {
        public IndustryTypeRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
