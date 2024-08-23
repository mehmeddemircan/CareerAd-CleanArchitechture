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

namespace QuickReserve.Application.Features.JobAdForms.Commands.Delete
{
    public partial class DeleteJobAdFormCommand : IRequest<IDataResult<DeletedJobAdFormDto>>
    {
        public int Id { get; set; }

        public class DeleteJobAdFormCommandHandler : IRequestHandler<DeleteJobAdFormCommand, IDataResult<DeletedJobAdFormDto>>
        {
            private readonly IJobAdFormRepository _jobadformRepository;
            private readonly IMapper _mapper;
            private readonly JobAdFormBusinessRules _jobadformBusinessRules;

            public DeleteJobAdFormCommandHandler(IJobAdFormRepository jobadformRepository, IMapper mapper,
                                             JobAdFormBusinessRules jobadformBusinessRules)
            {
                _jobadformRepository = jobadformRepository;
                _mapper = mapper;
                _jobadformBusinessRules = jobadformBusinessRules;
            }

            public async Task<IDataResult<DeletedJobAdFormDto>> Handle(DeleteJobAdFormCommand request, CancellationToken cancellationToken)
            {
                JobAdForm mappedEntity = _mapper.Map<JobAdForm>(request);
                JobAdForm deleteJobAdForm = await _jobadformRepository.DeleteAsync(mappedEntity);
                DeletedJobAdFormDto deletedJobAdFormDto = _mapper.Map<DeletedJobAdFormDto>(deleteJobAdForm);
                return new SuccessDataResult<DeletedJobAdFormDto>(deletedJobAdFormDto, ResultMessages.Deleted);

            }


        }

    }
}
