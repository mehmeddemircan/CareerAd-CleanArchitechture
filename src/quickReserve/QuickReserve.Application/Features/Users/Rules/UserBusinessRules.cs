using Core.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using QuickReserve.Domain.Entities.Auth;


using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickReserve.Application.Repositories;

namespace QuickReserve.Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

      

        public void UserShouldExistWhenRequested(User user)
        {
            if (user == null)
            {
                throw new BusinessException(ExceptionMessages.UserShouldExistWhenRequested);
            }
        }
    }
}
