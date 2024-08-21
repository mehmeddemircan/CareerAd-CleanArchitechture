using Core.Persistence.Repositories;
using QuickReserve.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Repositories
{
    public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim>
    {
    }
}
