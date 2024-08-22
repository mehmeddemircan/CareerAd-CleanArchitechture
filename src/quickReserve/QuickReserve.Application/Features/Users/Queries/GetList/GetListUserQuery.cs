
using AutoMapper;
using Core.Constants;
using Core.Persistence.Paging;
using Core.Requests;
using Core.Results;
using MediatR;
using QuickReserve.Application.Features.Users.Models;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.Users.Queries.GetList
{
    public class GetListUserQuery : IRequest<IDataResult<UserListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListUserQueryHandler : IRequestHandler<GetListUserQuery, IDataResult<UserListModel>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public GetListUserQueryHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<UserListModel>> Handle(GetListUserQuery request, CancellationToken cancellationToken)
            {
                IPaginate<User> users = await _userRepository.GetListAsync(
                                                
                                                index: request.PageRequest.Page,
                                                size: request.PageRequest.PageSize
                                                );

                UserListModel mappedUserListUser = _mapper.Map<UserListModel>(users);

                return new SuccessDataResult<UserListModel>(mappedUserListUser, ResultMessages.Listed);
            }
        }
    }
}
