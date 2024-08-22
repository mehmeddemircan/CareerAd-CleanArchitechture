
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

namespace QuickReserve.Application.Features.OperationClaims.Queries.GetById
{
    public class GetByIdOperationClaimQuery : IRequest<IDataResult<OperationClaimByIdDto>>
    {
        public int Id { get; set; }

        public class GetByIdOperationClaimQueryHandler : IRequestHandler<GetByIdOperationClaimQuery, IDataResult<OperationClaimByIdDto>>
        {
            private readonly IOperationClaimRepository _operationclaimRepository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _operationclaimBusinessRules;

            public GetByIdOperationClaimQueryHandler(IOperationClaimRepository operationclaimRepository, IMapper mapper, OperationClaimBusinessRules operationclaimBusinessRules)
            {
                _operationclaimRepository = operationclaimRepository;
                _mapper = mapper;
                _operationclaimBusinessRules = operationclaimBusinessRules;
            }

            public async Task<IDataResult<OperationClaimByIdDto>> Handle(GetByIdOperationClaimQuery request, CancellationToken cancellationToken)
            {
                OperationClaim? operationclaim = await _operationclaimRepository.GetAsync(b => b.Id == request.Id);

                _operationclaimBusinessRules.OperationClaimShouldExistWhenRequested(operationclaim);

                OperationClaimByIdDto operationclaimGetByIdDto = _mapper.Map<OperationClaimByIdDto>(operationclaim);
                return new SuccessDataResult<OperationClaimByIdDto>(operationclaimGetByIdDto,ResultMessages.Listed);
            }
        }
    }
}
