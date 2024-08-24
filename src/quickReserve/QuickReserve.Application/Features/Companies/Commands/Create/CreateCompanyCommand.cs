﻿using AutoMapper;
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

namespace QuickReserve.Application.Features.Companies.Commands.Create
{
    public partial class CreateCompanyCommand : IRequest<IDataResult<CreatedCompanyDto>>
    {
        public string Name { get; set; }

        public string? LogoImage { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public int IndustryTypeId { get; set; }
        public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, IDataResult<CreatedCompanyDto>>
        {
            private readonly ICompanyRepository _companyRepository;
            private readonly IMapper _mapper;
            private readonly CompanyBusinessRules _companyBusinessRules;

            public CreateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper,
                                             CompanyBusinessRules companyBusinessRules)
            {
                _companyRepository = companyRepository;
                _mapper = mapper;
                _companyBusinessRules = companyBusinessRules;
            }

            public async Task<IDataResult<CreatedCompanyDto>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
            {
                //await _companyBusinessRules.CompanyNameCanNotBeDuplicatedWhenInserted(request.Name);


                Company mappedEntity = _mapper.Map<Company>(request);
                Company createCompany = await _companyRepository.AddAsync(mappedEntity);
                CreatedCompanyDto createdCompanyDto = _mapper.Map<CreatedCompanyDto>(createCompany);
                return new SuccessDataResult<CreatedCompanyDto>(createdCompanyDto, ResultMessages.Added);
            }
        }
    }
}
