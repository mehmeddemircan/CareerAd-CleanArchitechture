using AutoMapper;
using Core.Persistence.Paging;
using QuickReserve.Application.Features.Companies.Commands.Create;
using QuickReserve.Application.Features.Companies.Commands.Delete;
using QuickReserve.Application.Features.Companies.Commands.Update;
using QuickReserve.Application.Features.Companies.Dtos;
using QuickReserve.Application.Features.Companies.Models;
using QuickReserve.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.Companies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Company, CreatedCompanyDto>().ReverseMap();
            CreateMap<Company, CreateCompanyCommand>().ReverseMap();
            CreateMap<IPaginate<Company>, CompanyListModel>().ReverseMap();
            CreateMap<Company, CompanyListDto>()
                .ForMember(dest => dest.IndustryTypeName, opt => opt.MapFrom(src => src.IndustryType.Name)).ReverseMap();



            CreateMap<Company, CompanyByIdDto>()
                 .ForMember(dest => dest.IndustryTypeName, opt => opt.MapFrom(src => src.IndustryType.Name)).ReverseMap();

            CreateMap<Company, UpdateCompanyCommand>().ReverseMap();
            CreateMap<Company, UpdatedCompanyDto>().ReverseMap();
            CreateMap<Company, DeletedCompanyDto>().ReverseMap();
            CreateMap<Company, DeleteCompanyCommand>().ReverseMap();
        }
    }
}
