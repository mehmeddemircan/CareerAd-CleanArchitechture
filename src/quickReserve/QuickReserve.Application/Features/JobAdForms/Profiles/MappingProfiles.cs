using AutoMapper;
using Core.Persistence.Paging;
using QuickReserve.Application.Features.Companies.Commands.Create;
using QuickReserve.Application.Features.Companies.Commands.Delete;
using QuickReserve.Application.Features.Companies.Commands.Update;
using QuickReserve.Application.Features.Companies.Dtos;
using QuickReserve.Application.Features.Companies.Models;
using QuickReserve.Application.Features.JobAdForms.Commands.Create;
using QuickReserve.Application.Features.JobAdForms.Commands.Delete;
using QuickReserve.Application.Features.JobAdForms.Commands.Update;
using QuickReserve.Application.Features.JobAdForms.Dtos;
using QuickReserve.Application.Features.JobAdForms.Models;
using QuickReserve.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.JobAdForms.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<JobAdForm, CreatedJobAdFormDto>().ReverseMap();
            CreateMap<JobAdForm, CreateJobAdFormCommand>().ReverseMap();
            CreateMap<IPaginate<JobAdForm>, JobAdFormListModel>().ReverseMap();
            CreateMap<JobAdForm, JobAdFormListDto>()
                      .ForMember(dest => dest.JobAd, opt => opt.MapFrom(src => src.JobAd)).ReverseMap();





            CreateMap<JobAdForm, JobAdFormByIdDto>()
                 .ForMember(dest => dest.JobAd, opt => opt.MapFrom(src => src.JobAd)).ReverseMap();
                 

            CreateMap<JobAdForm, UpdateJobAdFormCommand>().ReverseMap();
            CreateMap<JobAdForm, UpdatedJobAdFormDto>().ReverseMap();
            CreateMap<JobAdForm, DeletedJobAdFormDto>().ReverseMap();
            CreateMap<JobAdForm, DeleteJobAdFormCommand>().ReverseMap();
        }
    }
}
