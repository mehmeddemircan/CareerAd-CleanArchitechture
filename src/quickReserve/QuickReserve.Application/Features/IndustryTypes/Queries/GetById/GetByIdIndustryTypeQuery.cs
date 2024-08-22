using AutoMapper;
using Core.Constants;
using Core.Results;
using MediatR;
using QuickReserve.Application.Features.IndustryTypes.Dtos;
using QuickReserve.Application.Features.IndustryTypes.Rules;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities;
using QuickReserve.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.IndustryTypes.Queries.GetById
{
    public class GetByIdIndustryTypeQuery : IRequest<IDataResult<IndustryTypeByIdDto>>
    {
        public int Id { get; set; }

        public class GetByIdIndustryTypeQueryHandler : IRequestHandler<GetByIdIndustryTypeQuery, IDataResult<IndustryTypeByIdDto>>
        {
            private readonly IIndustryTypeRepository _industrytypeRepository;
            private readonly IMapper _mapper;
            private readonly IndustryTypeBusinessRules _industrytypeBusinessRules;

            public GetByIdIndustryTypeQueryHandler(IIndustryTypeRepository industrytypeRepository, IMapper mapper, IndustryTypeBusinessRules industrytypeBusinessRules)
            {
                _industrytypeRepository = industrytypeRepository;
                _mapper = mapper;
                _industrytypeBusinessRules = industrytypeBusinessRules;
            }

            public async Task<IDataResult<IndustryTypeByIdDto>> Handle(GetByIdIndustryTypeQuery request, CancellationToken cancellationToken)
            {
                IndustryType? industrytype = await _industrytypeRepository.GetAsync(b => b.Id == request.Id);

               // _industrytypeBusinessRules.IndustryTypeShouldExistWhenRequested(industrytype);

                IndustryTypeByIdDto industrytypeGetByIdDto = _mapper.Map<IndustryTypeByIdDto>(industrytype);
                return new SuccessDataResult<IndustryTypeByIdDto>(industrytypeGetByIdDto, ResultMessages.Listed);
            }
        }
    }
}
