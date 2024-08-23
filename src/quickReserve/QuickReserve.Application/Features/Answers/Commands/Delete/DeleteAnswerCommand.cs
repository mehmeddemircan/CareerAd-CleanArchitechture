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

namespace QuickReserve.Application.Features.Answers.Commands.Delete
{
    public partial class DeleteAnswerCommand : IRequest<IDataResult<DeletedAnswerDto>>
    {
        public int Id { get; set; }

        public class DeleteAnswerCommandHandler : IRequestHandler<DeleteAnswerCommand, IDataResult<DeletedAnswerDto>>
        {
            private readonly IAnswerRepository _answerRepository;
            private readonly IMapper _mapper;
            private readonly AnswerBusinessRules _answerBusinessRules;

            public DeleteAnswerCommandHandler(IAnswerRepository answerRepository, IMapper mapper,
                                             AnswerBusinessRules answerBusinessRules)
            {
                _answerRepository = answerRepository;
                _mapper = mapper;
                _answerBusinessRules = answerBusinessRules;
            }

            public async Task<IDataResult<DeletedAnswerDto>> Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
            {
                Answer mappedEntity = _mapper.Map<Answer>(request);
                Answer deleteAnswer = await _answerRepository.DeleteAsync(mappedEntity);
                DeletedAnswerDto deletedAnswerDto = _mapper.Map<DeletedAnswerDto>(deleteAnswer);
                return new SuccessDataResult<DeletedAnswerDto>(deletedAnswerDto, ResultMessages.Deleted);

            }


        }

    }
}
