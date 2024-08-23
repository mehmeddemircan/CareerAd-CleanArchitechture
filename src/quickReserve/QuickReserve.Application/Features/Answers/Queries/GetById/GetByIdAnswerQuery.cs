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

namespace QuickReserve.Application.Features.Answers.Queries.GetById
{
    public class GetByIdAnswerQuery : IRequest<IDataResult<AnswerByIdDto>>
    {
        public int Id { get; set; }

        public class GetByIdAnswerQueryHandler : IRequestHandler<GetByIdAnswerQuery, IDataResult<AnswerByIdDto>>
        {
            private readonly IAnswerRepository _answerRepository;
            private readonly IMapper _mapper;
            private readonly AnswerBusinessRules _answerBusinessRules;

            public GetByIdAnswerQueryHandler(IAnswerRepository answerRepository, IMapper mapper, AnswerBusinessRules answerBusinessRules)
            {
                _answerRepository = answerRepository;
                _mapper = mapper;
                _answerBusinessRules = answerBusinessRules;
            }

            public async Task<IDataResult<AnswerByIdDto>> Handle(GetByIdAnswerQuery request, CancellationToken cancellationToken)
            {
                Answer? answer = await _answerRepository.GetDetailsAsync(x => x.Id == request.Id, x => x.Question, x=> x.User);

                // _answerBusinessRules.AnswerShouldExistWhenRequested(answer);

                AnswerByIdDto answerGetByIdDto = _mapper.Map<AnswerByIdDto>(answer);
                return new SuccessDataResult<AnswerByIdDto>(answerGetByIdDto, ResultMessages.Listed);
            }
        }
    }
}
