
using AutoMapper;
using Core.Constants;
using Core.Results;

using MediatR;
using QuickReserve.Application.Features.OperationClaims.Dtos;
using QuickReserve.Application.Features.OperationClaims.Rules;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.OperationClaims.Commands.Delete
{
    public partial class DeleteOperationClaimCommand : IRequest<IDataResult<DeletedOperationClaimDto>>
    {
        public int Id { get; set; }

        public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, IDataResult<DeletedOperationClaimDto>>
        {
            private readonly IOperationClaimRepository _operationclaimRepository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _operationclaimBusinessRules;

            public DeleteOperationClaimCommandHandler(IOperationClaimRepository operationclaimRepository, IMapper mapper,
                                             OperationClaimBusinessRules operationclaimBusinessRules)
            {
                _operationclaimRepository = operationclaimRepository;
                _mapper = mapper;
                _operationclaimBusinessRules = operationclaimBusinessRules;
            }

            public async Task<IDataResult<DeletedOperationClaimDto>> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim mappedEntity = _mapper.Map<OperationClaim>(request);
                OperationClaim deleteOperationClaim = await _operationclaimRepository.DeleteAsync(mappedEntity);
                DeletedOperationClaimDto deletedOperationClaimDto = _mapper.Map<DeletedOperationClaimDto>(deleteOperationClaim);
                return new SuccessDataResult<DeletedOperationClaimDto>(deletedOperationClaimDto, ResultMessages.Deleted);

            }


        }

    }

}
