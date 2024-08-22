
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

namespace QuickReserve.Application.Features.OperationClaims.Commands.Update
{
    public partial class UpdateOperationClaimCommand : IRequest<IDataResult<UpdatedOperationClaimDto>>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, IDataResult<UpdatedOperationClaimDto>>
        {
            private readonly IOperationClaimRepository _operationclaimRepository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _operationclaimBusinessRules;

            public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationclaimRepository, IMapper mapper,
                                             OperationClaimBusinessRules operationclaimBusinessRules)
            {
                _operationclaimRepository = operationclaimRepository;
                _mapper = mapper;
                _operationclaimBusinessRules = operationclaimBusinessRules;
            }

            public async Task<IDataResult<UpdatedOperationClaimDto>> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _operationclaimBusinessRules.OperationClaimNameCanNotBeDuplicatedWhenInserted(request.Name);


                OperationClaim mappedEntity = _mapper.Map<OperationClaim>(request);
                mappedEntity.UpdatedTime = DateTime.UtcNow; 
                OperationClaim updateOperationClaim = await _operationclaimRepository.UpdateAsync(mappedEntity);
                UpdatedOperationClaimDto updatedOperationClaimDto = _mapper.Map<UpdatedOperationClaimDto>(updateOperationClaim);
                return new SuccessDataResult<UpdatedOperationClaimDto>(updatedOperationClaimDto, ResultMessages.Updated);
            }
        }
    }
}
