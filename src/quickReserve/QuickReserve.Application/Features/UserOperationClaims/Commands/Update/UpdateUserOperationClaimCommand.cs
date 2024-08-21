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

namespace QuickReserve.Application.Features.UserOperationClaims.Commands.Update
{
    public partial class UpdateUserOperationClaimCommand : IRequest<IDataResult<UpdatedUserOperationClaimDto>>
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int OperationClaimId { get; set; }

        public class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand, IDataResult<UpdatedUserOperationClaimDto>>
        {
            private readonly IUserOperationClaimRepository _useroperationclaimRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _useroperationclaimBusinessRules;

            public UpdateUserOperationClaimCommandHandler(IUserOperationClaimRepository useroperationclaimRepository, IMapper mapper,
                                             UserOperationClaimBusinessRules useroperationclaimBusinessRules)
            {
                _useroperationclaimRepository = useroperationclaimRepository;
                _mapper = mapper;
                _useroperationclaimBusinessRules = useroperationclaimBusinessRules;
            }

            public async Task<IDataResult<UpdatedUserOperationClaimDto>> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _useroperationclaimBusinessRules.UserOperationClaimCanNotBeDuplicatedWhenInsertedForUser(request.OperationClaimId, request.UserId);


                UserOperationClaim mappedEntity = _mapper.Map<UserOperationClaim>(request);
                mappedEntity.UpdatedTime = DateTime.UtcNow;
                UserOperationClaim updateUserOperationClaim = await _useroperationclaimRepository.UpdateAsync(mappedEntity);
                UpdatedUserOperationClaimDto updatedUserOperationClaimDto = _mapper.Map<UpdatedUserOperationClaimDto>(updateUserOperationClaim);
                return new SuccessDataResult<UpdatedUserOperationClaimDto>(updatedUserOperationClaimDto, ResultMessages.Updated);
            }
        }
    }
}
