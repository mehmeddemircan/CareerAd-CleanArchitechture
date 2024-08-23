using AutoMapper;
using Core.Constants;
using Core.Persistence.Paging;
using Core.Requests;
using Core.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuickReserve.Application.Features.Answers.Models;
using QuickReserve.Application.Features.Companies.Models;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.Answers.Queries.GetList
{
    public class GetListAnswerQuery : IRequest<IDataResult<AnswerListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListAnswerQueryHandler : IRequestHandler<GetListAnswerQuery, IDataResult<AnswerListModel>>
        {
            private readonly IAnswerRepository _answerRepository;
            private readonly IMapper _mapper;

            public GetListAnswerQueryHandler(IAnswerRepository answerRepository, IMapper mapper)
            {
                _answerRepository = answerRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<AnswerListModel>> Handle(GetListAnswerQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Answer> categories = await _answerRepository.GetListAsync(
                    include: source => source.Include(c => c.User).Include(x => x.Question),
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                AnswerListModel mappedAnswerListModel = _mapper.Map<AnswerListModel>(categories);

                return new SuccessDataResult<AnswerListModel>(mappedAnswerListModel, ResultMessages.Listed);
            }
        }
    }
}
