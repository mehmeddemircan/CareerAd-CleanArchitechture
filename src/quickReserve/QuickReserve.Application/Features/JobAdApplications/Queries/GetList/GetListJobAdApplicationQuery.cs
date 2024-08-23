using AutoMapper;
using Core.Constants;
using Core.Persistence.Paging;
using Core.Requests;
using Core.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuickReserve.Application.Features.Companies.Models;
using QuickReserve.Application.Features.JobAdApplications.Models;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.JobAdApplications.Queries.GetList
{
    public class GetListJobAdApplicationQuery : IRequest<IDataResult<JobAdApplicationListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListJobAdApplicationQueryHandler : IRequestHandler<GetListJobAdApplicationQuery, IDataResult<JobAdApplicationListModel>>
        {
            private readonly IJobAdApplicationRepository _jobadapplicationRepository;
            private readonly IMapper _mapper;

            public GetListJobAdApplicationQueryHandler(IJobAdApplicationRepository jobadapplicationRepository, IMapper mapper)
            {
                _jobadapplicationRepository = jobadapplicationRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<JobAdApplicationListModel>> Handle(GetListJobAdApplicationQuery request, CancellationToken cancellationToken)
            {
                IPaginate<JobAdApplication> categories = await _jobadapplicationRepository.GetListAsync(
                    include: source => source.Include(c => c.JobAd).ThenInclude(x => x.Company).Include(c => c.User),
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                JobAdApplicationListModel mappedJobAdApplicationListModel = _mapper.Map<JobAdApplicationListModel>(categories);

                return new SuccessDataResult<JobAdApplicationListModel>(mappedJobAdApplicationListModel, ResultMessages.Listed);
            }
        }
    }
}
