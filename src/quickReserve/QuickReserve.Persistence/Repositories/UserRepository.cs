using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities.Auth;
using QuickReserve.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Persistence.Repositories
{
    public class UserRepository : EfBaseRepository<User, BaseDbContext>, IUserRepository
    {
        private readonly BaseDbContext Context;

    
        public UserRepository(BaseDbContext context) : base(context)
        {
            Context = context;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            var result = from operationClaim in Context.OperationClaims
                         join userOperationClaim in Context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.Id
                         select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            return result.ToList();
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            return Context.Set<User>().SingleOrDefault(filter);
        }
    }

}

