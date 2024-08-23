using AutoMapper;
using Core.Constants;
using Core.Results;
using MediatR;
using QuickReserve.Application.Features.Companies.Dtos;
using QuickReserve.Application.Features.Companies.Rules;
using QuickReserve.Application.Features.Questions.Dtos;
using QuickReserve.Application.Features.Questions.Rules;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.Questions.Commands.Create
{
    public partial class CreateQuestionCommand : IRequest<IDataResult<CreatedQuestionDto>>
    {
        public string Text { get; set; }  
        public int JobAdFormId { get; set; }
        public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, IDataResult<CreatedQuestionDto>>
        {
            private readonly IQuestionRepository _questionRepository;
            private readonly IMapper _mapper;
            private readonly QuestionBusinessRules _questionBusinessRules;

            public CreateQuestionCommandHandler(IQuestionRepository questionRepository, IMapper mapper,
                                             QuestionBusinessRules questionBusinessRules)
            {
                _questionRepository = questionRepository;
                _mapper = mapper;
                _questionBusinessRules = questionBusinessRules;
            }

            public async Task<IDataResult<CreatedQuestionDto>> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
            {
                //await _questionBusinessRules.QuestionNameCanNotBeDuplicatedWhenInserted(request.Name);


                Question mappedEntity = _mapper.Map<Question>(request);
                Question createQuestion = await _questionRepository.AddAsync(mappedEntity);
                CreatedQuestionDto createdQuestionDto = _mapper.Map<CreatedQuestionDto>(createQuestion);
                return new SuccessDataResult<CreatedQuestionDto>(createdQuestionDto, ResultMessages.Added);
            }
        }
    }
}
