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

namespace QuickReserve.Application.Features.JobAds.Commands.Create
{
    public partial class CreateJobAdCommand : IRequest<IDataResult<CreatedJobAdDto>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string SalaryRange { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime Deadline { get; set; }
        public int CompanyId { get; set; }
        public class CreateJobAdCommandHandler : IRequestHandler<CreateJobAdCommand, IDataResult<CreatedJobAdDto>>
        {
            private readonly IJobAdRepository _jobadRepository;
            private readonly IMapper _mapper;
            private readonly JobAdBusinessRules _jobadBusinessRules;

            public CreateJobAdCommandHandler(IJobAdRepository jobadRepository, IMapper mapper,
                                             JobAdBusinessRules jobadBusinessRules)
            {
                _jobadRepository = jobadRepository;
                _mapper = mapper;
                _jobadBusinessRules = jobadBusinessRules;
            }

            public async Task<IDataResult<CreatedJobAdDto>> Handle(CreateJobAdCommand request, CancellationToken cancellationToken)
            {
                //await _jobadBusinessRules.JobAdNameCanNotBeDuplicatedWhenInserted(request.Name);


                JobAd mappedEntity = _mapper.Map<JobAd>(request);
                JobAd createJobAd = await _jobadRepository.AddAsync(mappedEntity);
                CreatedJobAdDto createdJobAdDto = _mapper.Map<CreatedJobAdDto>(createJobAd);
                return new SuccessDataResult<CreatedJobAdDto>(createdJobAdDto, ResultMessages.Added);
            }
        }
    }
}
