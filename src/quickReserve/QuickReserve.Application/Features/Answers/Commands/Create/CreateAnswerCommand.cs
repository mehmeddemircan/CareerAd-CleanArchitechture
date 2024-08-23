using AutoMapper;
using Core.Constants;
using Core.Results;
using MediatR;
using QuickReserve.Application.Features.Answers.Dtos;
using QuickReserve.Application.Features.Answers.Rules;
using QuickReserve.Application.Features.Companies.Dtos;
using QuickReserve.Application.Features.Companies.Rules;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.Answers.Commands.Create
{
    public partial class CreateAnswerCommand : IRequest<IDataResult<CreatedAnswerDto>>
    {
        public string Response { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommand, IDataResult<CreatedAnswerDto>>
        {
            private readonly IAnswerRepository _answerRepository;
            private readonly IMapper _mapper;
            private readonly AnswerBusinessRules _answerBusinessRules;

            public CreateAnswerCommandHandler(IAnswerRepository answerRepository, IMapper mapper,
                                             AnswerBusinessRules answerBusinessRules)
            {
                _answerRepository = answerRepository;
                _mapper = mapper;
                _answerBusinessRules = answerBusinessRules;
            }

            public async Task<IDataResult<CreatedAnswerDto>> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
            {

                Answer mappedEntity = _mapper.Map<Answer>(request);
                Answer createAnswer = await _answerRepository.AddAsync(mappedEntity);
                CreatedAnswerDto createdAnswerDto = _mapper.Map<CreatedAnswerDto>(createAnswer);
                return new SuccessDataResult<CreatedAnswerDto>(createdAnswerDto, ResultMessages.Added);
            }
        }
    }
}
