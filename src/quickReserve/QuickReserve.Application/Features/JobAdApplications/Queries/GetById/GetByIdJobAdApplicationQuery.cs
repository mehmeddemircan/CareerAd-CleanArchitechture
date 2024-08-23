using AutoMapper;
using Core.Constants;
using Core.Results;
using MediatR;
using QuickReserve.Application.Features.Companies.Dtos;
using QuickReserve.Application.Features.Companies.Rules;
using QuickReserve.Application.Features.JobAdApplications.Dtos;
using QuickReserve.Application.Features.JobAdApplications.Rules;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.JobAdApplications.Queries.GetById
{
    public class GetByIdJobAdApplicationQuery : IRequest<IDataResult<JobAdApplicationByIdDto>>
    {
        public int Id { get; set; }

        public class GetByIdJobAdApplicationQueryHandler : IRequestHandler<GetByIdJobAdApplicationQuery, IDataResult<JobAdApplicationByIdDto>>
        {
            private readonly IJobAdApplicationRepository _jobadapplicationRepository;
            private readonly IMapper _mapper;
            private readonly JobAdApplicationBusinessRules _jobadapplicationBusinessRules;

            public GetByIdJobAdApplicationQueryHandler(IJobAdApplicationRepository jobadapplicationRepository, IMapper mapper, JobAdApplicationBusinessRules jobadapplicationBusinessRules)
            {
                _jobadapplicationRepository = jobadapplicationRepository;
                _mapper = mapper;
                _jobadapplicationBusinessRules = jobadapplicationBusinessRules;
            }

            public async Task<IDataResult<JobAdApplicationByIdDto>> Handle(GetByIdJobAdApplicationQuery request, CancellationToken cancellationToken)
            {
                JobAdApplication? jobadapplication = await _jobadapplicationRepository.GetDetailsAsync(x => x.Id == request.Id, x => x.JobAd,x=> x.JobAd.Company, x => x.User);

                // _jobadapplicationBusinessRules.JobAdApplicationShouldExistWhenRequested(jobadapplication);

                JobAdApplicationByIdDto jobadapplicationGetByIdDto = _mapper.Map<JobAdApplicationByIdDto>(jobadapplication);
                return new SuccessDataResult<JobAdApplicationByIdDto>(jobadapplicationGetByIdDto, ResultMessages.Listed);
            }
        }
    }
}
