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

namespace QuickReserve.Application.Features.UserOperationClaims.Commands.Delete
{
    public partial class DeleteUserOperationClaimCommand : IRequest<IDataResult<DeletedUserOperationClaimDto>>
    {
        public int Id { get; set; }

        public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, IDataResult<DeletedUserOperationClaimDto>>
        {
            private readonly IUserOperationClaimRepository _useroperationclaimRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _useroperationclaimBusinessRules;

            public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository useroperationclaimRepository, IMapper mapper,
                                             UserOperationClaimBusinessRules useroperationclaimBusinessRules)
            {
                _useroperationclaimRepository = useroperationclaimRepository;
                _mapper = mapper;
                _useroperationclaimBusinessRules = useroperationclaimBusinessRules;
            }

            public async Task<IDataResult<DeletedUserOperationClaimDto>> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                UserOperationClaim mappedEntity = _mapper.Map<UserOperationClaim>(request);
                UserOperationClaim deleteUserOperationClaim = await _useroperationclaimRepository.DeleteAsync(mappedEntity);
                DeletedUserOperationClaimDto deletedUserOperationClaimDto = _mapper.Map<DeletedUserOperationClaimDto>(deleteUserOperationClaim);
                return new SuccessDataResult<DeletedUserOperationClaimDto>(deletedUserOperationClaimDto, ResultMessages.Deleted);

            }


        }
    }
}
