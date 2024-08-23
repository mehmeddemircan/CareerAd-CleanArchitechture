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

namespace QuickReserve.Application.Features.JobAds.Commands.Update
{
    public partial class UpdateJobAdCommand : IRequest<IDataResult<UpdatedJobAdDto>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string SalaryRange { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime Deadline { get; set; }
        public int CompanyId { get; set; }

        public class UpdateJobAdCommandHandler : IRequestHandler<UpdateJobAdCommand, IDataResult<UpdatedJobAdDto>>
        {
            private readonly IJobAdRepository _jobadRepository;
            private readonly IMapper _mapper;
            private readonly JobAdBusinessRules _jobadBusinessRules;

            public UpdateJobAdCommandHandler(IJobAdRepository jobadRepository, IMapper mapper,
                                             JobAdBusinessRules jobadBusinessRules)
            {
                _jobadRepository = jobadRepository;
                _mapper = mapper;
                _jobadBusinessRules = jobadBusinessRules;
            }

            public async Task<IDataResult<UpdatedJobAdDto>> Handle(UpdateJobAdCommand request, CancellationToken cancellationToken)
            {
                //await _jobadBusinessRules.JobAdNameCanNotBeDuplicatedWhenInserted(request.Name);


                JobAd mappedEntity = _mapper.Map<JobAd>(request);
                mappedEntity.UpdatedTime = DateTime.UtcNow;
                JobAd updateJobAd = await _jobadRepository.UpdateAsync(mappedEntity);
                UpdatedJobAdDto updatedJobAdDto = _mapper.Map<UpdatedJobAdDto>(updateJobAd);
                return new SuccessDataResult<UpdatedJobAdDto>(updatedJobAdDto, ResultMessages.Updated);
            }
        }
    }
}
