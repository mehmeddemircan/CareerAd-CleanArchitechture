using AutoMapper;
using Core.Persistence.Paging;
using QuickReserve.Application.Features.IndustryTypes.Commands.Create;

using QuickReserve.Application.Features.IndustryTypes.Commands.Delete;
using QuickReserve.Application.Features.IndustryTypes.Commands.Update;
using QuickReserve.Application.Features.IndustryTypes.Dtos;
using QuickReserve.Application.Features.IndustryTypes.Models;
using QuickReserve.Domain.Entities;
using QuickReserve.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.IndustryTypes.Profiles
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<IndustryType, CreatedIndustryTypeDto>().ReverseMap();
            CreateMap<IndustryType, CreateIndustryTypeCommand>().ReverseMap();
            CreateMap<IPaginate<IndustryType>, IndustryTypeListModel>().ReverseMap();
            CreateMap<IndustryType, IndustryTypeListDto>().ReverseMap();
            CreateMap<IndustryType, IndustryTypeByIdDto>().ReverseMap();
            CreateMap<IndustryType, UpdateIndustryTypeCommand>().ReverseMap();
            CreateMap<IndustryType, UpdatedIndustryTypeDto>().ReverseMap();
            CreateMap<IndustryType, DeletedIndustryTypeDto>().ReverseMap();
            CreateMap<IndustryType, DeleteIndustryTypeCommand>().ReverseMap();
        }
    }
}
