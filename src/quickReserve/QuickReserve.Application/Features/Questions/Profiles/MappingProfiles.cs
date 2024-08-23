using AutoMapper;
using Core.Persistence.Paging;
using QuickReserve.Application.Features.Companies.Commands.Create;
using QuickReserve.Application.Features.Companies.Commands.Delete;
using QuickReserve.Application.Features.Companies.Commands.Update;
using QuickReserve.Application.Features.Companies.Dtos;
using QuickReserve.Application.Features.Companies.Models;
using QuickReserve.Application.Features.Questions.Commands.Create;
using QuickReserve.Application.Features.Questions.Commands.Delete;
using QuickReserve.Application.Features.Questions.Commands.Update;
using QuickReserve.Application.Features.Questions.Dtos;
using QuickReserve.Application.Features.Questions.Models;
using QuickReserve.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.Questions.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Question, CreatedQuestionDto>().ReverseMap();
            CreateMap<Question, CreateQuestionCommand>().ReverseMap();
            CreateMap<IPaginate<Question>, QuestionListModel>().ReverseMap();
            CreateMap<Question, QuestionListDto>()
                .ForMember(dest => dest.JobAdForm, opt => opt.MapFrom(src => src.JobAdForm)).ReverseMap();



            CreateMap<Question, QuestionByIdDto>()
                    .ForMember(dest => dest.JobAdForm, opt => opt.MapFrom(src => src.JobAdForm)).ReverseMap();

            CreateMap<Question, UpdateQuestionCommand>().ReverseMap();
            CreateMap<Question, UpdatedQuestionDto>().ReverseMap();
            CreateMap<Question, DeletedQuestionDto>().ReverseMap();
            CreateMap<Question, DeleteQuestionCommand>().ReverseMap();
        }
    }
}
