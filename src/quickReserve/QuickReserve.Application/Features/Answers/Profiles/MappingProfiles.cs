using AutoMapper;
using Core.Persistence.Paging;
using QuickReserve.Application.Features.Answers.Commands.Create;
using QuickReserve.Application.Features.Answers.Commands.Delete;
using QuickReserve.Application.Features.Answers.Commands.Update;
using QuickReserve.Application.Features.Answers.Dtos;
using QuickReserve.Application.Features.Answers.Models;
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

namespace QuickReserve.Application.Features.Answers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Answer, CreatedAnswerDto>().ReverseMap();
            CreateMap<Answer, CreateAnswerCommand>().ReverseMap();
            CreateMap<IPaginate<Answer>, AnswerListModel>().ReverseMap();
            CreateMap<Answer, AnswerListDto>()
                .ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.Question.Text))
                .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.User.LastName))
                .ReverseMap();



            CreateMap<Answer, AnswerByIdDto>()
                .ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.Question.Text))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User)).ReverseMap();

            CreateMap<Answer, UpdateAnswerCommand>().ReverseMap();
            CreateMap<Answer, UpdatedAnswerDto>().ReverseMap();
            CreateMap<Answer, DeletedAnswerDto>().ReverseMap();
            CreateMap<Answer, DeleteAnswerCommand>().ReverseMap();
        }
    }
}
