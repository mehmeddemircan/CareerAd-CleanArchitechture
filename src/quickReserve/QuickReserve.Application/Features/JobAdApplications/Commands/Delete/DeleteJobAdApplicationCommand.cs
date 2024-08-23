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

namespace QuickReserve.Application.Features.JobAdApplications.Commands.Delete
{
    public partial class DeleteJobAdApplicationCommand : IRequest<IDataResult<DeletedJobAdApplicationDto>>
    {
        public int Id { get; set; }

        public class DeleteJobAdApplicationCommandHandler : IRequestHandler<DeleteJobAdApplicationCommand, IDataResult<DeletedJobAdApplicationDto>>
        {
            private readonly IJobAdApplicationRepository _jobadapplicationRepository;
            private readonly IMapper _mapper;
            private readonly JobAdApplicationBusinessRules _jobadapplicationBusinessRules;

            public DeleteJobAdApplicationCommandHandler(IJobAdApplicationRepository jobadapplicationRepository, IMapper mapper,
                                             JobAdApplicationBusinessRules jobadapplicationBusinessRules)
            {
                _jobadapplicationRepository = jobadapplicationRepository;
                _mapper = mapper;
                _jobadapplicationBusinessRules = jobadapplicationBusinessRules;
            }

            public async Task<IDataResult<DeletedJobAdApplicationDto>> Handle(DeleteJobAdApplicationCommand request, CancellationToken cancellationToken)
            {
                JobAdApplication mappedEntity = _mapper.Map<JobAdApplication>(request);
                JobAdApplication deleteJobAdApplication = await _jobadapplicationRepository.DeleteAsync(mappedEntity);
                DeletedJobAdApplicationDto deletedJobAdApplicationDto = _mapper.Map<DeletedJobAdApplicationDto>(deleteJobAdApplication);
                return new SuccessDataResult<DeletedJobAdApplicationDto>(deletedJobAdApplicationDto, ResultMessages.Deleted);

            }


        }

    }
}
