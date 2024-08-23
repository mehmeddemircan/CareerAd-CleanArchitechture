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

namespace QuickReserve.Application.Features.Answers.Commands.Update
{
    public partial class UpdateAnswerCommand : IRequest<IDataResult<UpdatedAnswerDto>>
    {
        public int Id { get; set; }
        public string Response { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }

        public class UpdateAnswerCommandHandler : IRequestHandler<UpdateAnswerCommand, IDataResult<UpdatedAnswerDto>>
        {
            private readonly IAnswerRepository _answerRepository;
            private readonly IMapper _mapper;
            private readonly AnswerBusinessRules _answerBusinessRules;

            public UpdateAnswerCommandHandler(IAnswerRepository answerRepository, IMapper mapper,
                                             AnswerBusinessRules answerBusinessRules)
            {
                _answerRepository = answerRepository;
                _mapper = mapper;
                _answerBusinessRules = answerBusinessRules;
            }

            public async Task<IDataResult<UpdatedAnswerDto>> Handle(UpdateAnswerCommand request, CancellationToken cancellationToken)
            {
               


                Answer mappedEntity = _mapper.Map<Answer>(request);
                mappedEntity.UpdatedTime = DateTime.UtcNow;
                Answer updateAnswer = await _answerRepository.UpdateAsync(mappedEntity);
                UpdatedAnswerDto updatedAnswerDto = _mapper.Map<UpdatedAnswerDto>(updateAnswer);
                return new SuccessDataResult<UpdatedAnswerDto>(updatedAnswerDto, ResultMessages.Updated);
            }
        }
    }
}
