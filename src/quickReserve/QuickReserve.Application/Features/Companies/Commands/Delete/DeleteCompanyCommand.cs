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

namespace QuickReserve.Application.Features.Companies.Commands.Delete
{
    public partial class DeleteCompanyCommand : IRequest<IDataResult<DeletedCompanyDto>>
    {
        public int Id { get; set; }

        public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, IDataResult<DeletedCompanyDto>>
        {
            private readonly ICompanyRepository _companyRepository;
            private readonly IMapper _mapper;
            private readonly CompanyBusinessRules _companyBusinessRules;

            public DeleteCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper,
                                             CompanyBusinessRules companyBusinessRules)
            {
                _companyRepository = companyRepository;
                _mapper = mapper;
                _companyBusinessRules = companyBusinessRules;
            }

            public async Task<IDataResult<DeletedCompanyDto>> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
            {
                Company mappedEntity = _mapper.Map<Company>(request);
                Company deleteCompany = await _companyRepository.DeleteAsync(mappedEntity);
                DeletedCompanyDto deletedCompanyDto = _mapper.Map<DeletedCompanyDto>(deleteCompany);
                return new SuccessDataResult<DeletedCompanyDto>(deletedCompanyDto, ResultMessages.Deleted);

            }


        }

    }
}
