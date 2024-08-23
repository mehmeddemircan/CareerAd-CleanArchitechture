using AutoMapper;
using Core.Constants;
using Core.Persistence.Paging;
using Core.Requests;
using Core.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuickReserve.Application.Features.Companies.Models;
using QuickReserve.Application.Features.JobAdForms.Models;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.JobAdForms.Queries.GetList
{
    public class GetListJobAdFormQuery : IRequest<IDataResult<JobAdFormListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListJobAdFormQueryHandler : IRequestHandler<GetListJobAdFormQuery, IDataResult<JobAdFormListModel>>
        {
            private readonly IJobAdFormRepository _jobadformRepository;
            private readonly IMapper _mapper;

            public GetListJobAdFormQueryHandler(IJobAdFormRepository jobadformRepository, IMapper mapper)
            {
                _jobadformRepository = jobadformRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<JobAdFormListModel>> Handle(GetListJobAdFormQuery request, CancellationToken cancellationToken)
            {
                IPaginate<JobAdForm> categories = await _jobadformRepository.GetListAsync(
                    include: source => source.Include(c => c.JobAd).ThenInclude(x => x.Company),
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                JobAdFormListModel mappedJobAdFormListModel = _mapper.Map<JobAdFormListModel>(categories);

                return new SuccessDataResult<JobAdFormListModel>(mappedJobAdFormListModel, ResultMessages.Listed);
            }
        }
    }
}
