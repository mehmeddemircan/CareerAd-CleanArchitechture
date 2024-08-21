using AutoMapper;
using Core.Persistence.Paging;
using QuickReserve.Application.Features.UserOperationClaims.Commands.Create;
using QuickReserve.Application.Features.UserOperationClaims.Commands.Delete;
using QuickReserve.Application.Features.UserOperationClaims.Commands.Update;
using QuickReserve.Application.Features.UserOperationClaims.Dtos;
using QuickReserve.Application.Features.UserOperationClaims.Models;
using QuickReserve.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.UserOperationClaims.Profiles
{
       public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserOperationClaim,CreatedUserOperationClaimDto>().ReverseMap();
            CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
            CreateMap<IPaginate<UserOperationClaim>,UserOperationClaimListModel>()
               .ReverseMap();
            CreateMap<UserOperationClaim, UserOperationClaimListDto>()
                 .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
                 .ForMember(dest => dest.OperationClaimName, opt => opt.MapFrom(src => src.OperationClaim.Name))
                .ReverseMap();

            CreateMap<UserOperationClaim, UserOperationClaimByIdDto>()
             .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
             .ForMember(dest => dest.OperationClaimName, opt => opt.MapFrom(src => src.OperationClaim.Name))
            .ReverseMap();


            CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, UpdatedUserOperationClaimDto>().ReverseMap();
            CreateMap<UserOperationClaim, DeletedUserOperationClaimDto>().ReverseMap();
            CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();
        }
    }
}
