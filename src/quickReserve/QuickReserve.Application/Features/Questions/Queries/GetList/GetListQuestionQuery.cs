using AutoMapper;
using Core.Constants;
using Core.Persistence.Paging;
using Core.Requests;
using Core.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuickReserve.Application.Features.Companies.Models;
using QuickReserve.Application.Features.Questions.Models;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.Questions.Queries.GetList
{
    public class GetListQuestionQuery : IRequest<IDataResult<QuestionListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListQuestionQueryHandler : IRequestHandler<GetListQuestionQuery, IDataResult<QuestionListModel>>
        {
            private readonly IQuestionRepository _questionRepository;
            private readonly IMapper _mapper;

            public GetListQuestionQueryHandler(IQuestionRepository questionRepository, IMapper mapper)
            {
                _questionRepository = questionRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<QuestionListModel>> Handle(GetListQuestionQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Question> categories = await _questionRepository.GetListAsync(
                    include: source => source.Include(c => c.JobAdForm).ThenInclude(c => c.JobAd).ThenInclude(c => c.Company),
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                QuestionListModel mappedQuestionListModel = _mapper.Map<QuestionListModel>(categories);

                return new SuccessDataResult<QuestionListModel>(mappedQuestionListModel, ResultMessages.Listed);
            }
        }
    }
}
