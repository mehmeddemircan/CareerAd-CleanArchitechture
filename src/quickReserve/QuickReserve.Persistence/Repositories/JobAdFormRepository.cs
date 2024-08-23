using Core.Persistence.Repositories;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities;
using QuickReserve.Persistence.Contexts;

namespace QuickReserve.Persistence.Repositories
{
    public class JobAdFormRepository : EfBaseRepository<JobAdForm, BaseDbContext>, IJobAdFormRepository
    {
        public JobAdFormRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
