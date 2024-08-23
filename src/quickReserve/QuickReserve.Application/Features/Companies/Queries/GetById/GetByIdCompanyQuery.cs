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

namespace QuickReserve.Application.Features.Companies.Queries.GetById
{
    public class GetByIdCompanyQuery : IRequest<IDataResult<CompanyByIdDto>>
    {
        public int Id { get; set; }

        public class GetByIdCompanyQueryHandler : IRequestHandler<GetByIdCompanyQuery, IDataResult<CompanyByIdDto>>
        {
            private readonly ICompanyRepository _companyRepository;
            private readonly IMapper _mapper;
            private readonly CompanyBusinessRules _companyBusinessRules;

            public GetByIdCompanyQueryHandler(ICompanyRepository companyRepository, IMapper mapper, CompanyBusinessRules companyBusinessRules)
            {
                _companyRepository = companyRepository;
                _mapper = mapper;
                _companyBusinessRules = companyBusinessRules;
            }

            public async Task<IDataResult<CompanyByIdDto>> Handle(GetByIdCompanyQuery request, CancellationToken cancellationToken)
            {
                Company? company = await _companyRepository.GetDetailsAsync(x => x.Id == request.Id,x => x.IndustryType);

                // _companyBusinessRules.CompanyShouldExistWhenRequested(company);

                CompanyByIdDto companyGetByIdDto = _mapper.Map<CompanyByIdDto>(company);
                return new SuccessDataResult<CompanyByIdDto>(companyGetByIdDto, ResultMessages.Listed);
            }
        }
    }
}
