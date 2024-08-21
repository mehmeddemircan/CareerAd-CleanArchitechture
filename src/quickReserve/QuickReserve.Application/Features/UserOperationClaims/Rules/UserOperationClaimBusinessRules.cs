using Core.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IUserOperationClaimRepository _useroperationclaimRepository;

        public UserOperationClaimBusinessRules(IUserOperationClaimRepository useroperationclaimRepository)
        {
            _useroperationclaimRepository = useroperationclaimRepository;
        }

        public async Task UserOperationClaimCanNotBeDuplicatedWhenInsertedForUser(int operationClaimId, int userId)
        {
            IPaginate<UserOperationClaim> result = await _useroperationclaimRepository.GetListAsync(b => b.OperationClaimId == operationClaimId && b.UserId == userId);
            if (result.Items.Any())
            {
                throw new BusinessException(ExceptionMessages.UserOperationClaimNameExists);
            }
        }

        public void UserOperationClaimShouldExistWhenRequested(UserOperationClaim useroperationclaim)
        {
            if (useroperationclaim == null)
            {
                throw new BusinessException(ExceptionMessages.UserOperationClaimShouldExistWhenRequested);
            }
        }
    }
}
