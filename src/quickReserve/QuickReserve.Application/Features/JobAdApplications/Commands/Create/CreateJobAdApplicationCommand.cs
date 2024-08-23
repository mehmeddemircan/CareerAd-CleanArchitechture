using AutoMapper;
using Core.Constants;
using Core.Results;
using MediatR;

using QuickReserve.Application.Features.JobAdApplications.Dtos;
using QuickReserve.Application.Features.JobAdApplications.Rules;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.JobAdApplications.Commands.Create
{
    public partial class CreateJobAdApplicationCommand : IRequest<IDataResult<CreatedJobAdApplicationDto>>
    {
        public int JobAdId { get; set; }
        public int UserId { get; set; }
        public class CreateJobAdApplicationCommandHandler : IRequestHandler<CreateJobAdApplicationCommand, IDataResult<CreatedJobAdApplicationDto>>
        {
            private readonly IJobAdApplicationRepository _jobadapplicationRepository;
            private readonly IMapper _mapper;
            private readonly JobAdApplicationBusinessRules _jobadapplicationBusinessRules;

            public CreateJobAdApplicationCommandHandler(IJobAdApplicationRepository jobadapplicationRepository, IMapper mapper,
                                             JobAdApplicationBusinessRules jobadapplicationBusinessRules)
            {
                _jobadapplicationRepository = jobadapplicationRepository;
                _mapper = mapper;
                _jobadapplicationBusinessRules = jobadapplicationBusinessRules;
            }

            public async Task<IDataResult<CreatedJobAdApplicationDto>> Handle(CreateJobAdApplicationCommand request, CancellationToken cancellationToken)
            {
                //await _jobadapplicationBusinessRules.JobAdApplicationNameCanNotBeDuplicatedWhenInserted(request.Name);


                JobAdApplication mappedEntity = _mapper.Map<JobAdApplication>(request);
                JobAdApplication createJobAdApplication = await _jobadapplicationRepository.AddAsync(mappedEntity);
                CreatedJobAdApplicationDto createdJobAdApplicationDto = _mapper.Map<CreatedJobAdApplicationDto>(createJobAdApplication);
                return new SuccessDataResult<CreatedJobAdApplicationDto>(createdJobAdApplicationDto, ResultMessages.Added);
            }
        }
    }
}
