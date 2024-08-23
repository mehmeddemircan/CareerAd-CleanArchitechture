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

namespace QuickReserve.Application.Features.JobAdForms.Queries.GetById
{
    public class GetByIdJobAdFormQuery : IRequest<IDataResult<JobAdFormByIdDto>>
    {
        public int Id { get; set; }

        public class GetByIdJobAdFormQueryHandler : IRequestHandler<GetByIdJobAdFormQuery, IDataResult<JobAdFormByIdDto>>
        {
            private readonly IJobAdFormRepository _jobadformRepository;
            private readonly IMapper _mapper;
            private readonly JobAdFormBusinessRules _jobadformBusinessRules;

            public GetByIdJobAdFormQueryHandler(IJobAdFormRepository jobadformRepository, IMapper mapper, JobAdFormBusinessRules jobadformBusinessRules)
            {
                _jobadformRepository = jobadformRepository;
                _mapper = mapper;
                _jobadformBusinessRules = jobadformBusinessRules;
            }

            public async Task<IDataResult<JobAdFormByIdDto>> Handle(GetByIdJobAdFormQuery request, CancellationToken cancellationToken)
            {
                JobAdForm? jobadform = await _jobadformRepository.GetDetailsAsync(x => x.Id == request.Id, x => x.JobAd ,x => x.JobAd.Company);

                // _jobadformBusinessRules.JobAdFormShouldExistWhenRequested(jobadform);

                JobAdFormByIdDto jobadformGetByIdDto = _mapper.Map<JobAdFormByIdDto>(jobadform);
                return new SuccessDataResult<JobAdFormByIdDto>(jobadformGetByIdDto, ResultMessages.Listed);
            }
        }
    }
}
