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

namespace QuickReserve.Application.Features.Questions.Commands.Delete
{
    public partial class DeleteQuestionCommand : IRequest<IDataResult<DeletedQuestionDto>>
    {
        public int Id { get; set; }

        public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, IDataResult<DeletedQuestionDto>>
        {
            private readonly IQuestionRepository _questionRepository;
            private readonly IMapper _mapper;
            private readonly QuestionBusinessRules _questionBusinessRules;

            public DeleteQuestionCommandHandler(IQuestionRepository questionRepository, IMapper mapper,
                                             QuestionBusinessRules questionBusinessRules)
            {
                _questionRepository = questionRepository;
                _mapper = mapper;
                _questionBusinessRules = questionBusinessRules;
            }

            public async Task<IDataResult<DeletedQuestionDto>> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
            {
                Question mappedEntity = _mapper.Map<Question>(request);
                Question deleteQuestion = await _questionRepository.DeleteAsync(mappedEntity);
                DeletedQuestionDto deletedQuestionDto = _mapper.Map<DeletedQuestionDto>(deleteQuestion);
                return new SuccessDataResult<DeletedQuestionDto>(deletedQuestionDto, ResultMessages.Deleted);

            }


        }

    }
}
