

using AutoMapper;
using Core.Persistence.Paging;
using QuickReserve.Application.Features.Users.Commands.Delete;
using QuickReserve.Application.Features.Users.Dtos;
using QuickReserve.Application.Features.Users.Models;
using QuickReserve.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.Users.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<IPaginate<User>, UserListModel>()
              .ReverseMap();
            CreateMap<User, UserListDto>().ReverseMap();
            CreateMap<User, UserByIdDto>().ReverseMap();

            CreateMap<User, DeletedUserDto>().ReverseMap();
            CreateMap<User, DeleteUserCommand>().ReverseMap();
        }
    }
}
