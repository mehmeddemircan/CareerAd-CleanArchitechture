using AutoMapper;
using Core.Constants;
using Core.Results;
using MediatR;
using QuickReserve.Application.Features.Companies.Dtos;
using QuickReserve.Application.Features.Companies.Rules;
using QuickReserve.Application.Features.JobAds.Dtos;
using QuickReserve.Application.Features.JobAds.Rules;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.JobAds.Commands.Delete
{
    public partial class DeleteJobAdCommand : IRequest<IDataResult<DeletedJobAdDto>>
    {
        public int Id { get; set; }

        public class DeleteJobAdCommandHandler : IRequestHandler<DeleteJobAdCommand, IDataResult<DeletedJobAdDto>>
        {
            private readonly IJobAdRepository _jobadRepository;
            private readonly IMapper _mapper;
            private readonly JobAdBusinessRules _jobadBusinessRules;

            public DeleteJobAdCommandHandler(IJobAdRepository jobadRepository, IMapper mapper,
                                             JobAdBusinessRules jobadBusinessRules)
            {
                _jobadRepository = jobadRepository;
                _mapper = mapper;
                _jobadBusinessRules = jobadBusinessRules;
            }

            public async Task<IDataResult<DeletedJobAdDto>> Handle(DeleteJobAdCommand request, CancellationToken cancellationToken)
            {
                JobAd mappedEntity = _mapper.Map<JobAd>(request);
                JobAd deleteJobAd = await _jobadRepository.DeleteAsync(mappedEntity);
                DeletedJobAdDto deletedJobAdDto = _mapper.Map<DeletedJobAdDto>(deleteJobAd);
                return new SuccessDataResult<DeletedJobAdDto>(deletedJobAdDto, ResultMessages.Deleted);

            }


        }

    }
}
