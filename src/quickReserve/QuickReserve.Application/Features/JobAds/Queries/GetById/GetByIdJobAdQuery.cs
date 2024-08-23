using AutoMapper;
using Core.Constants;
using Core.Results;
using MediatR;
using QuickReserve.Application.Features.JobAds.Dtos;
using QuickReserve.Application.Features.JobAds.Rules;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.JobAds.Queries.GetById
{
    public class GetByIdJobAdQuery : IRequest<IDataResult<JobAdByIdDto>>
    {
        public int Id { get; set; }

        public class GetByIdJobAdQueryHandler : IRequestHandler<GetByIdJobAdQuery, IDataResult<JobAdByIdDto>>
        {
            private readonly IJobAdRepository _jobadRepository;
            private readonly IMapper _mapper;
            private readonly JobAdBusinessRules _jobadBusinessRules;

            public GetByIdJobAdQueryHandler(IJobAdRepository jobadRepository, IMapper mapper, JobAdBusinessRules jobadBusinessRules)
            {
                _jobadRepository = jobadRepository;
                _mapper = mapper;
                _jobadBusinessRules = jobadBusinessRules;
            }

            public async Task<IDataResult<JobAdByIdDto>> Handle(GetByIdJobAdQuery request, CancellationToken cancellationToken)
            {
                JobAd? jobad = await _jobadRepository.GetDetailsAsync(x => x.Id == request.Id, x => x.Company);

                // _jobadBusinessRules.JobAdShouldExistWhenRequested(jobad);

                JobAdByIdDto jobadGetByIdDto = _mapper.Map<JobAdByIdDto>(jobad);
                return new SuccessDataResult<JobAdByIdDto>(jobadGetByIdDto, ResultMessages.Listed);
            }
        }
    }
}
