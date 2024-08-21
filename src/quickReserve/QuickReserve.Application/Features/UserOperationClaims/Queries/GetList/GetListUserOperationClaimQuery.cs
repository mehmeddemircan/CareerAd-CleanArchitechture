using AutoMapper;
using Core.Constants;
using Core.Persistence.Paging;
using Core.Requests;
using Core.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuickReserve.Application.Features.UserOperationClaims.Models;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.UserOperationClaims.Queries.GetList
{
    public class GetListUserOperationClaimQuery : IRequest<IDataResult<UserOperationClaimListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListUserOperationClaimQueryHandler : IRequestHandler<GetListUserOperationClaimQuery, IDataResult<UserOperationClaimListModel>>
        {
            private readonly IUserOperationClaimRepository _useroperationclaimRepository;
            private readonly IMapper _mapper;

            public GetListUserOperationClaimQueryHandler(IUserOperationClaimRepository useroperationclaimRepository, IMapper mapper)
            {
                _useroperationclaimRepository = useroperationclaimRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<UserOperationClaimListModel>> Handle(GetListUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserOperationClaim> useroperationclaims = await _useroperationclaimRepository.GetListAsync(include: source =>
                                                 source.Include(uoc => uoc.User)
                                                .Include(uoc => uoc.OperationClaim),
                                                index: request.PageRequest.Page,
                                                size: request.PageRequest.PageSize
                                                );

                UserOperationClaimListModel mappedUserOperationClaimListUserOperationClaim = _mapper.Map<UserOperationClaimListModel>(useroperationclaims);

                return new SuccessDataResult<UserOperationClaimListModel>(mappedUserOperationClaimListUserOperationClaim, ResultMessages.Listed);
            }
        }
    }
}
