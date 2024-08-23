using Core.Persistence.Repositories;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities;
using QuickReserve.Persistence.Contexts;

namespace QuickReserve.Persistence.Repositories
{
    public class AnswerRepository : EfBaseRepository<Answer, BaseDbContext>, IAnswerRepository
    {
        public AnswerRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
