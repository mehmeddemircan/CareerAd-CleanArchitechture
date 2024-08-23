using AutoMapper;
using Core.Constants;
using Core.Persistence.Paging;
using Core.Requests;
using Core.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuickReserve.Application.Features.Companies.Models;

using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.Companies.Queries.GetList
{
    public class GetListCompanyQuery : IRequest<IDataResult<CompanyListModel>>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListCompanyQueryHandler : IRequestHandler<GetListCompanyQuery, IDataResult<CompanyListModel>>
        {
            private readonly ICompanyRepository _companyRepository;
            private readonly IMapper _mapper;

            public GetListCompanyQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
            {
                _companyRepository = companyRepository;
                _mapper = mapper;
            }

            public async Task<IDataResult<CompanyListModel>> Handle(GetListCompanyQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Company> categories = await _companyRepository.GetListAsync(
                    include : source => source.Include(c => c.IndustryType),
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                CompanyListModel mappedCompanyListModel = _mapper.Map<CompanyListModel>(categories);

                return new SuccessDataResult<CompanyListModel>(mappedCompanyListModel, ResultMessages.Listed);
            }
        }
    }
}
