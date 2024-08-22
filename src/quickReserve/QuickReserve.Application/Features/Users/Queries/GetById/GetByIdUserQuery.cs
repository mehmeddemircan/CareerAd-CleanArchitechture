
using AutoMapper;
using Core.Constants;
using Core.Results;
using MediatR;
using QuickReserve.Application.Features.Users.Dtos;
using QuickReserve.Application.Features.Users.Rules;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.Users.Queries.GetById
{
    public class GetByIdUserQuery : IRequest<IDataResult<UserByIdDto>>
    {
        public int Id { get; set; }
        public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, IDataResult<UserByIdDto>>
        {
            private readonly IUserRepository _userRepository;
            private readonly UserBusinessRules _userBusinessRules;
            private readonly IMapper _mapper;

            public GetByIdUserQueryHandler(IUserRepository userRepository, IMapper mapper,UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _userBusinessRules = userBusinessRules;
                _mapper = mapper;
            }

            public async Task<IDataResult<UserByIdDto>> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(b => b.Id == request.Id);

                _userBusinessRules.UserShouldExistWhenRequested(user);

                UserByIdDto mappedUserByIdUser = _mapper.Map<UserByIdDto>(user);

                return new SuccessDataResult<UserByIdDto>(mappedUserByIdUser, ResultMessages.Listed);
            }
        }
    }
}
