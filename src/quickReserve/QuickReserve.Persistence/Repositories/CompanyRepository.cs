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
    public class CompanyRepository : EfBaseRepository<Company, BaseDbContext>, ICompanyRepository
    {
        public CompanyRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
