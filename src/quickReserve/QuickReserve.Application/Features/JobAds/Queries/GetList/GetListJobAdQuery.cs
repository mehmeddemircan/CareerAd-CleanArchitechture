using AutoMapper;
using Core.Constants;
using Core.Persistence.Paging;
using Core.Requests;
using Core.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuickReserve.Application.Features.Companies.Models;
using QuickReserve.Application.Features.JobAds.Models;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.JobAds.Queries.GetList
{
    public class GetListJobAdQuery : IRequest<IDataResult<JobAdListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListJobAdQueryHandler : IRequestHandler<GetListJobAdQuery, IDataResult<JobAdListModel>>
        {
            private readonly IJobAdRepository _jobadRepository;
            private readonly IMapper _mapper;

            public GetListJobAdQueryHandler(IJobAdRepository jobadRepository, IMapper mapper)
            {
                _jobadRepository = jobadRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<JobAdListModel>> Handle(GetListJobAdQuery request, CancellationToken cancellationToken)
            {
                IPaginate<JobAd> categories = await _jobadRepository.GetListAsync(
                    include: source => source.Include(c => c.Company),
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                JobAdListModel mappedJobAdListModel = _mapper.Map<JobAdListModel>(categories);

                return new SuccessDataResult<JobAdListModel>(mappedJobAdListModel, ResultMessages.Listed);
            }
        }
    }
}
