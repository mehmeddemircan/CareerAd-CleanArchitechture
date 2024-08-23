using AutoMapper;
using Core.Constants;
using Core.Results;
using MediatR;
using QuickReserve.Application.Features.Companies.Dtos;
using QuickReserve.Application.Features.Companies.Rules;
using QuickReserve.Application.Features.JobAdForms.Dtos;
using QuickReserve.Application.Features.JobAdForms.Rules;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.JobAdForms.Commands.Update
{
    public partial class UpdateJobAdFormCommand : IRequest<IDataResult<UpdatedJobAdFormDto>>
    {
        public int Id { get; set; }
        public int JobAdId { get; set; }

        public class UpdateJobAdFormCommandHandler : IRequestHandler<UpdateJobAdFormCommand, IDataResult<UpdatedJobAdFormDto>>
        {
            private readonly IJobAdFormRepository _jobadformRepository;
            private readonly IMapper _mapper;
            private readonly JobAdFormBusinessRules _jobadformBusinessRules;

            public UpdateJobAdFormCommandHandler(IJobAdFormRepository jobadformRepository, IMapper mapper,
                                             JobAdFormBusinessRules jobadformBusinessRules)
            {
                _jobadformRepository = jobadformRepository;
                _mapper = mapper;
                _jobadformBusinessRules = jobadformBusinessRules;
            }

            public async Task<IDataResult<UpdatedJobAdFormDto>> Handle(UpdateJobAdFormCommand request, CancellationToken cancellationToken)
            {
                //await _jobadformBusinessRules.JobAdFormNameCanNotBeDuplicatedWhenInserted(request.Name);


                JobAdForm mappedEntity = _mapper.Map<JobAdForm>(request);
                mappedEntity.UpdatedTime = DateTime.UtcNow;
                JobAdForm updateJobAdForm = await _jobadformRepository.UpdateAsync(mappedEntity);
                UpdatedJobAdFormDto updatedJobAdFormDto = _mapper.Map<UpdatedJobAdFormDto>(updateJobAdForm);
                return new SuccessDataResult<UpdatedJobAdFormDto>(updatedJobAdFormDto, ResultMessages.Updated);
            }
        }
    }
}
