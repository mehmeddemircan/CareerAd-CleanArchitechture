using AutoMapper;
using Core.Persistence.Paging;
using QuickReserve.Application.Features.Companies.Commands.Create;
using QuickReserve.Application.Features.Companies.Commands.Delete;
using QuickReserve.Application.Features.Companies.Commands.Update;
using QuickReserve.Application.Features.Companies.Dtos;
using QuickReserve.Application.Features.Companies.Models;
using QuickReserve.Application.Features.JobAdApplications.Commands.Create;
using QuickReserve.Application.Features.JobAdApplications.Commands.Delete;
using QuickReserve.Application.Features.JobAdApplications.Commands.Update;
using QuickReserve.Application.Features.JobAdApplications.Dtos;
using QuickReserve.Application.Features.JobAdApplications.Models;
using QuickReserve.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.JobAdApplications.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {

            CreateMap<JobAdApplication, CreatedJobAdApplicationDto>().ReverseMap();
            CreateMap<JobAdApplication, CreateJobAdApplicationCommand>().ReverseMap();
            CreateMap<IPaginate<JobAdApplication>, JobAdApplicationListModel>().ReverseMap();
            CreateMap<JobAdApplication, JobAdApplicationListDto>()
                .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.JobAd, opt => opt.MapFrom(src => src.JobAd)).ReverseMap();



            CreateMap<JobAdApplication, JobAdApplicationByIdDto>()
                .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.JobAd, opt => opt.MapFrom(src => src.JobAd)).ReverseMap();


            CreateMap<JobAdApplication, UpdateJobAdApplicationCommand>().ReverseMap();
            CreateMap<JobAdApplication, UpdatedJobAdApplicationDto>().ReverseMap();
            CreateMap<JobAdApplication, DeletedJobAdApplicationDto>().ReverseMap();
            CreateMap<JobAdApplication, DeleteJobAdApplicationCommand>().ReverseMap();
        }
    }
}
