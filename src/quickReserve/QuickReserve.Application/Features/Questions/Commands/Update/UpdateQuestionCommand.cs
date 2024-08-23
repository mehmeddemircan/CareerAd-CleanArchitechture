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

namespace QuickReserve.Application.Features.Questions.Commands.Update
{
    public partial class UpdateQuestionCommand : IRequest<IDataResult<UpdatedQuestionDto>>
    {
        public int Id { get; set; }
        public string Text { get; set; }  
        public int JobAdFormId { get; set; }

        public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, IDataResult<UpdatedQuestionDto>>
        {
            private readonly IQuestionRepository _questionRepository;
            private readonly IMapper _mapper;
            private readonly QuestionBusinessRules _questionBusinessRules;

            public UpdateQuestionCommandHandler(IQuestionRepository questionRepository, IMapper mapper,
                                             QuestionBusinessRules questionBusinessRules)
            {
                _questionRepository = questionRepository;
                _mapper = mapper;
                _questionBusinessRules = questionBusinessRules;
            }

            public async Task<IDataResult<UpdatedQuestionDto>> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
            {
                //await _questionBusinessRules.QuestionNameCanNotBeDuplicatedWhenInserted(request.Name);


                Question mappedEntity = _mapper.Map<Question>(request);
                mappedEntity.UpdatedTime = DateTime.UtcNow;
                Question updateQuestion = await _questionRepository.UpdateAsync(mappedEntity);
                UpdatedQuestionDto updatedQuestionDto = _mapper.Map<UpdatedQuestionDto>(updateQuestion);
                return new SuccessDataResult<UpdatedQuestionDto>(updatedQuestionDto, ResultMessages.Updated);
            }
        }
    }
}
