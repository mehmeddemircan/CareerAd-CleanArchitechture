using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
    public static class ExceptionMessages
    {

        #region User
        public const string UserShouldExistWhenRequested = "Requested user does not exist";
        #endregion

        #region UserOperationClaim
        public const string UserOperationClaimNameExists = "UserOperationClaim Name Already exists";
        public const string UserOperationClaimShouldExistWhenRequested = "Requested brand does not exist";
        #endregion


        #region OperationClaim
        public const string OperationClaimNameExists = "OperationClaim Name Already exists";
        public const string OperationClaimShouldExistWhenRequested = "Requested OperationClaim does not exist";
        #endregion
    }
}
