using Core.Persistence.Repositories;
using QuickReserve.Domain.Entities;

namespace QuickReserve.Application.Repositories
{
    public interface IAnswerRepository : IAsyncRepository<Answer>
    {
    }
}
