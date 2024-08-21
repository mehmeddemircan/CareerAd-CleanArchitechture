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

namespace QuickReserve.Application.Features.UserOperationClaims.Commands.Create
{
    public class CreateUserOperationClaimCommand : IRequest<IDataResult<CreatedUserOperationClaimDto>>
    {

        public int UserId { get; set; }

        public int OperationClaimId { get; set; }



        public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, IDataResult<CreatedUserOperationClaimDto>>
        {
            private readonly IUserOperationClaimRepository _useroperationclaimRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _useroperationclaimBusinessRules;

            public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository useroperationclaimRepository, IMapper mapper,
                                             UserOperationClaimBusinessRules useroperationclaimBusinessRules)
            {
                _useroperationclaimRepository = useroperationclaimRepository;
                _mapper = mapper;
                _useroperationclaimBusinessRules = useroperationclaimBusinessRules;
            }

            public async Task<IDataResult<CreatedUserOperationClaimDto>> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _useroperationclaimBusinessRules.UserOperationClaimCanNotBeDuplicatedWhenInsertedForUser(request.OperationClaimId, request.UserId);


                UserOperationClaim mappedEntity = _mapper.Map<UserOperationClaim>(request);
                UserOperationClaim createUserOperationClaim = await _useroperationclaimRepository.AddAsync(mappedEntity);
                CreatedUserOperationClaimDto createdUserOperationClaimDto = _mapper.Map<CreatedUserOperationClaimDto>(createUserOperationClaim);
                return new SuccessDataResult<CreatedUserOperationClaimDto>(createdUserOperationClaimDto, ResultMessages.Added);
            }
        }

    }
}
