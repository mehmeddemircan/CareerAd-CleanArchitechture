using AutoMapper;
using Core.Constants;
using Core.Persistence.Paging;
using Core.Requests;
using Core.Results;
using MediatR;
using QuickReserve.Application.Features.IndustryTypes.Models;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities;
using QuickReserve.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.IndustryTypes.Queries.GetList
{
    public class GetListIndustryTypeQuery : IRequest<IDataResult<IndustryTypeListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListIndustryTypeQueryHandler : IRequestHandler<GetListIndustryTypeQuery, IDataResult<IndustryTypeListModel>>
        {
            private readonly IIndustryTypeRepository _industrytypeRepository;
            private readonly IMapper _mapper;

            public GetListIndustryTypeQueryHandler(IIndustryTypeRepository industrytypeRepository, IMapper mapper)
            {
                _industrytypeRepository = industrytypeRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<IndustryTypeListModel>> Handle(GetListIndustryTypeQuery request, CancellationToken cancellationToken)
            {
                IPaginate<IndustryType> categories = await _industrytypeRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                IndustryTypeListModel mappedIndustryTypeListModel = _mapper.Map<IndustryTypeListModel>(categories);

                return new SuccessDataResult<IndustryTypeListModel>(mappedIndustryTypeListModel, ResultMessages.Listed);
            }
        }
    }
}
