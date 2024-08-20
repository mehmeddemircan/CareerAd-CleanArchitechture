using Core.Persistence.Repositories;
using QuickReserve.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Repositories
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        User Get(Expression<Func<User, bool>> filter);

    }
}
