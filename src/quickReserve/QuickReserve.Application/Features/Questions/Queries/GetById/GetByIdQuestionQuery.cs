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

namespace QuickReserve.Application.Features.Questions.Queries.GetById
{
    public class GetByIdQuestionQuery : IRequest<IDataResult<QuestionByIdDto>>
    {
        public int Id { get; set; }

        public class GetByIdQuestionQueryHandler : IRequestHandler<GetByIdQuestionQuery, IDataResult<QuestionByIdDto>>
        {
            private readonly IQuestionRepository _questionRepository;
            private readonly IMapper _mapper;
            private readonly QuestionBusinessRules _questionBusinessRules;

            public GetByIdQuestionQueryHandler(IQuestionRepository questionRepository, IMapper mapper, QuestionBusinessRules questionBusinessRules)
            {
                _questionRepository = questionRepository;
                _mapper = mapper;
                _questionBusinessRules = questionBusinessRules;
            }

            public async Task<IDataResult<QuestionByIdDto>> Handle(GetByIdQuestionQuery request, CancellationToken cancellationToken)
            {
                Question? question = await _questionRepository.GetDetailsAsync(x => x.Id == request.Id, x => x.JobAdForm, x => x.JobAdForm.JobAd, x=> x.JobAdForm.JobAd.Company);

                // _questionBusinessRules.QuestionShouldExistWhenRequested(question);

                QuestionByIdDto questionGetByIdDto = _mapper.Map<QuestionByIdDto>(question);
                return new SuccessDataResult<QuestionByIdDto>(questionGetByIdDto, ResultMessages.Listed);
            }
        }
    }
}
