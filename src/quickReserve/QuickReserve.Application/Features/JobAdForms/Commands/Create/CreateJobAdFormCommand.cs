using AutoMapper;
using Core.Constants;
using Core.Results;
using MediatR;
using QuickReserve.Application.Features.JobAdForms.Dtos;
using QuickReserve.Application.Features.JobAdForms.Rules;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.JobAdForms.Commands.Create
{
    public partial class CreateJobAdFormCommand : IRequest<IDataResult<CreatedJobAdFormDto>>
    {
        public int JobAdId { get; set; }
        public class CreateJobAdFormCommandHandler : IRequestHandler<CreateJobAdFormCommand, IDataResult<CreatedJobAdFormDto>>
        {
            private readonly IJobAdFormRepository _jobadformRepository;
            private readonly IMapper _mapper;
            private readonly JobAdFormBusinessRules _jobadformBusinessRules;

            public CreateJobAdFormCommandHandler(IJobAdFormRepository jobadformRepository, IMapper mapper,
                                             JobAdFormBusinessRules jobadformBusinessRules)
            {
                _jobadformRepository = jobadformRepository;
                _mapper = mapper;
                _jobadformBusinessRules = jobadformBusinessRules;
            }

            public async Task<IDataResult<CreatedJobAdFormDto>> Handle(CreateJobAdFormCommand request, CancellationToken cancellationToken)
            {
                //await _jobadformBusinessRules.JobAdFormNameCanNotBeDuplicatedWhenInserted(request.Name);


                JobAdForm mappedEntity = _mapper.Map<JobAdForm>(request);
                JobAdForm createJobAdForm = await _jobadformRepository.AddAsync(mappedEntity);
                CreatedJobAdFormDto createdJobAdFormDto = _mapper.Map<CreatedJobAdFormDto>(createJobAdForm);
                return new SuccessDataResult<CreatedJobAdFormDto>(createdJobAdFormDto, ResultMessages.Added);
            }
        }
    }
}
