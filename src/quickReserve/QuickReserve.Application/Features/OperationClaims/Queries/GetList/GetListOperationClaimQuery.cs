
using AutoMapper;

using Core.Constants;
using Core.Persistence.Paging;
using Core.Requests;
using Core.Results;

using MediatR;
using QuickReserve.Application.Features.OperationClaims.Models;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.OperationClaims.Queries.GetListOperationClaim
{
    public class GetListOperationClaimQuery : IRequest<IDataResult<OperationClaimListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListOperationClaimQueryHandler : IRequestHandler<GetListOperationClaimQuery, IDataResult<OperationClaimListModel>>
        {
            private readonly IOperationClaimRepository _operationclaimRepository;
            private readonly IMapper _mapper;

            public GetListOperationClaimQueryHandler(IOperationClaimRepository operationclaimRepository, IMapper mapper)
            {
                _operationclaimRepository = operationclaimRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<OperationClaimListModel>> Handle(GetListOperationClaimQuery request, CancellationToken cancellationToken)
            {
                IPaginate<OperationClaim> categories = await _operationclaimRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                OperationClaimListModel mappedOperationClaimListModel = _mapper.Map<OperationClaimListModel>(categories);

                return new SuccessDataResult<OperationClaimListModel>(mappedOperationClaimListModel,ResultMessages.Listed);
            }
        }
    }
}
