

using AutoMapper;
using Core.Constants;
using Core.Results;
using MediatR;
using QuickReserve.Application.Features.Users.Dtos;
using QuickReserve.Application.Features.Users.Rules;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.Users.Commands.Delete
{
    public partial class DeleteUserCommand : IRequest<IDataResult<DeletedUserDto>>
    {
        public int Id { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, IDataResult<DeletedUserDto>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper,
                                             UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<IDataResult<DeletedUserDto>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                User mappedEntity = _mapper.Map<User>(request);
                User deleteUser = await _userRepository.DeleteAsync(mappedEntity);
                DeletedUserDto deletedUserDto = _mapper.Map<DeletedUserDto>(deleteUser);
                return new SuccessDataResult<DeletedUserDto>(deletedUserDto, ResultMessages.Deleted);

            }


        }
    }
}
