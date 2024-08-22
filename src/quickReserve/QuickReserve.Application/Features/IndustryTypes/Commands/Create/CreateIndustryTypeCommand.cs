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

namespace QuickReserve.Application.Features.IndustryTypes.Commands.Create
{
    public partial class CreateIndustryTypeCommand : IRequest<IDataResult<CreatedIndustryTypeDto>>
    {
        public string Name { get; set; }

        public class CreateIndustryTypeCommandHandler : IRequestHandler<CreateIndustryTypeCommand, IDataResult<CreatedIndustryTypeDto>>
        {
            private readonly IIndustryTypeRepository _industrytypeRepository;
            private readonly IMapper _mapper;
            private readonly IndustryTypeBusinessRules _industrytypeBusinessRules;

            public CreateIndustryTypeCommandHandler(IIndustryTypeRepository industrytypeRepository, IMapper mapper,
                                             IndustryTypeBusinessRules industrytypeBusinessRules)
            {
                _industrytypeRepository = industrytypeRepository;
                _mapper = mapper;
                _industrytypeBusinessRules = industrytypeBusinessRules;
            }

            public async Task<IDataResult<CreatedIndustryTypeDto>> Handle(CreateIndustryTypeCommand request, CancellationToken cancellationToken)
            {
                //await _industrytypeBusinessRules.IndustryTypeNameCanNotBeDuplicatedWhenInserted(request.Name);


                IndustryType mappedEntity = _mapper.Map<IndustryType>(request);
                IndustryType createIndustryType = await _industrytypeRepository.AddAsync(mappedEntity);
                CreatedIndustryTypeDto createdIndustryTypeDto = _mapper.Map<CreatedIndustryTypeDto>(createIndustryType);
                return new SuccessDataResult<CreatedIndustryTypeDto>(createdIndustryTypeDto, ResultMessages.Added);
            }
        }
    }
}
