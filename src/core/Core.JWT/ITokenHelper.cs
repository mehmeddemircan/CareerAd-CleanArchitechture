using Microsoft.Extensions.Configuration;
using QuickReserve.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.JWT
{
    public interface ITokenHelper
    {
        IConfiguration Configuration { get; }

        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
