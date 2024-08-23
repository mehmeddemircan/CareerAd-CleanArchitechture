using Core.Persistence.Repositories;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities;
using QuickReserve.Persistence.Contexts;

namespace QuickReserve.Persistence.Repositories
{
    public class JobAdApplicationRepository : EfBaseRepository<JobAdApplication, BaseDbContext>, IJobAdApplicationRepository
    {
        public JobAdApplicationRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
