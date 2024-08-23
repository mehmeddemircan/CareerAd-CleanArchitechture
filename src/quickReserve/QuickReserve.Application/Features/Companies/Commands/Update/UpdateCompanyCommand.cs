using AutoMapper;
using Core.Constants;
using Core.Results;
using MediatR;
using QuickReserve.Application.Features.Companies.Dtos;
using QuickReserve.Application.Features.Companies.Rules;

using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.Companies.Commands.Update
{
    public partial class UpdateCompanyCommand : IRequest<IDataResult<UpdatedCompanyDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public int IndustryTypeId { get; set; }

        public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, IDataResult<UpdatedCompanyDto>>
        {
            private readonly ICompanyRepository _companyRepository;
            private readonly IMapper _mapper;
            private readonly CompanyBusinessRules _companyBusinessRules;

            public UpdateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper,
                                             CompanyBusinessRules companyBusinessRules)
            {
                _companyRepository = companyRepository;
                _mapper = mapper;
                _companyBusinessRules = companyBusinessRules;
            }

            public async Task<IDataResult<UpdatedCompanyDto>> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
            {
                //await _companyBusinessRules.CompanyNameCanNotBeDuplicatedWhenInserted(request.Name);


                Company mappedEntity = _mapper.Map<Company>(request);
                mappedEntity.UpdatedTime = DateTime.UtcNow;
                Company updateCompany = await _companyRepository.UpdateAsync(mappedEntity);
                UpdatedCompanyDto updatedCompanyDto = _mapper.Map<UpdatedCompanyDto>(updateCompany);
                return new SuccessDataResult<UpdatedCompanyDto>(updatedCompanyDto, ResultMessages.Updated);
            }
        }
    }
}
