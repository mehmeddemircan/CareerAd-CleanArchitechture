using AutoMapper;
using Core.Constants;
using Core.Results;
using MediatR;
using QuickReserve.Application.Features.UserOperationClaims.Dtos;
using QuickReserve.Application.Features.UserOperationClaims.Rules;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.UserOperationClaims.Queries.GetById
{
    public class GetByIdUserOperationClaimQuery : IRequest<IDataResult<UserOperationClaimByIdDto>>
    {
        public int Id { get; set; }

        public class GetByIdUserOperationClaimQueryHandler : IRequestHandler<GetByIdUserOperationClaimQuery, IDataResult<UserOperationClaimByIdDto>>
        {
            private readonly IUserOperationClaimRepository _useroperationclaimRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _useroperationclaimBusinessRules;

            public GetByIdUserOperationClaimQueryHandler(IUserOperationClaimRepository useroperationclaimRepository, IMapper mapper, UserOperationClaimBusinessRules useroperationclaimBusinessRules)
            {
                _useroperationclaimRepository = useroperationclaimRepository;
                _mapper = mapper;
                _useroperationclaimBusinessRules = useroperationclaimBusinessRules;
            }

            public async Task<IDataResult<UserOperationClaimByIdDto>> Handle(GetByIdUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                UserOperationClaim? useroperationclaim = await _useroperationclaimRepository.GetDetailsAsync(b => b.Id == request.Id, b => b.User,
        b => b.OperationClaim);

                _useroperationclaimBusinessRules.UserOperationClaimShouldExistWhenRequested(useroperationclaim);

                UserOperationClaimByIdDto useroperationclaimGetByIdDto = _mapper.Map<UserOperationClaimByIdDto>(useroperationclaim);
                return new SuccessDataResult<UserOperationClaimByIdDto>(useroperationclaimGetByIdDto, ResultMessages.Listed);
            }
        }
    }
}
