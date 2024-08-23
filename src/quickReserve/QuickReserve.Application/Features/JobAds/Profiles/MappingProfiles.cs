using AutoMapper;
using Core.Persistence.Paging;
using QuickReserve.Application.Features.Companies.Commands.Create;
using QuickReserve.Application.Features.Companies.Commands.Delete;
using QuickReserve.Application.Features.Companies.Commands.Update;
using QuickReserve.Application.Features.Companies.Dtos;
using QuickReserve.Application.Features.Companies.Models;
using QuickReserve.Application.Features.JobAds.Commands.Create;
using QuickReserve.Application.Features.JobAds.Commands.Delete;
using QuickReserve.Application.Features.JobAds.Commands.Update;
using QuickReserve.Application.Features.JobAds.Dtos;
using QuickReserve.Application.Features.JobAds.Models;
using QuickReserve.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.JobAds.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<JobAd, CreatedJobAdDto>().ReverseMap();
            CreateMap<JobAd, CreateJobAdCommand>().ReverseMap();
            CreateMap<IPaginate<JobAd>, JobAdListModel>().ReverseMap();
            CreateMap<JobAd, JobAdListDto>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name)).ReverseMap();



            CreateMap<JobAd, JobAdByIdDto>()
                 .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name)).ReverseMap();

            CreateMap<JobAd, UpdateJobAdCommand>().ReverseMap();
            CreateMap<JobAd, UpdatedJobAdDto>().ReverseMap();
            CreateMap<JobAd, DeletedJobAdDto>().ReverseMap();
            CreateMap<JobAd, DeleteJobAdCommand>().ReverseMap();
        }
    }
}
