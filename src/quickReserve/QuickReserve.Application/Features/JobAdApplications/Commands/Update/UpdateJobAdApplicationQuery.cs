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

namespace QuickReserve.Application.Features.JobAdApplications.Commands.Update
{
    public partial class UpdateJobAdApplicationCommand : IRequest<IDataResult<UpdatedJobAdApplicationDto>>
    {
        public int Id { get; set; }
        public int JobAdId { get; set; }
        public int UserId { get; set; }

        public class UpdateJobAdApplicationCommandHandler : IRequestHandler<UpdateJobAdApplicationCommand, IDataResult<UpdatedJobAdApplicationDto>>
        {
            private readonly IJobAdApplicationRepository _jobadapplicationRepository;
            private readonly IMapper _mapper;
            private readonly JobAdApplicationBusinessRules _jobadapplicationBusinessRules;

            public UpdateJobAdApplicationCommandHandler(IJobAdApplicationRepository jobadapplicationRepository, IMapper mapper,
                                             JobAdApplicationBusinessRules jobadapplicationBusinessRules)
            {
                _jobadapplicationRepository = jobadapplicationRepository;
                _mapper = mapper;
                _jobadapplicationBusinessRules = jobadapplicationBusinessRules;
            }

            public async Task<IDataResult<UpdatedJobAdApplicationDto>> Handle(UpdateJobAdApplicationCommand request, CancellationToken cancellationToken)
            {
                //await _jobadapplicationBusinessRules.JobAdApplicationNameCanNotBeDuplicatedWhenInserted(request.Name);


                JobAdApplication mappedEntity = _mapper.Map<JobAdApplication>(request);
                mappedEntity.UpdatedTime = DateTime.UtcNow;
                JobAdApplication updateJobAdApplication = await _jobadapplicationRepository.UpdateAsync(mappedEntity);
                UpdatedJobAdApplicationDto updatedJobAdApplicationDto = _mapper.Map<UpdatedJobAdApplicationDto>(updateJobAdApplication);
                return new SuccessDataResult<UpdatedJobAdApplicationDto>(updatedJobAdApplicationDto, ResultMessages.Updated);
            }
        }
    }
}
