
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

namespace QuickReserve.Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public partial class CreateOperationClaimCommand : IRequest<IDataResult<CreatedOperationClaimDto>>
    {
        public string Name { get; set; }

        public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, IDataResult<CreatedOperationClaimDto>>
        {
            private readonly IOperationClaimRepository _operationclaimRepository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _operationclaimBusinessRules;

            public CreateOperationClaimCommandHandler(IOperationClaimRepository operationclaimRepository, IMapper mapper,
                                             OperationClaimBusinessRules operationclaimBusinessRules)
            {
                _operationclaimRepository = operationclaimRepository;
                _mapper = mapper;
                _operationclaimBusinessRules = operationclaimBusinessRules;
            }

            public async Task<IDataResult<CreatedOperationClaimDto>> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _operationclaimBusinessRules.OperationClaimNameCanNotBeDuplicatedWhenInserted(request.Name);


                OperationClaim mappedEntity = _mapper.Map<OperationClaim>(request);
                OperationClaim createOperationClaim = await _operationclaimRepository.AddAsync(mappedEntity);
                CreatedOperationClaimDto createdOperationClaimDto = _mapper.Map<CreatedOperationClaimDto>(createOperationClaim);
                return new SuccessDataResult<CreatedOperationClaimDto>(createdOperationClaimDto, ResultMessages.Added);
            }
        }
    }
}
