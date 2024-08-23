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

namespace QuickReserve.Application.Features.IndustryTypes.Commands.Update
{
    public partial class UpdateIndustryTypeCommand : IRequest<IDataResult<UpdatedIndustryTypeDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateIndustryTypeCommandHandler : IRequestHandler<UpdateIndustryTypeCommand, IDataResult<UpdatedIndustryTypeDto>>
        {
            private readonly IIndustryTypeRepository _industrytypeRepository;
            private readonly IMapper _mapper;
            private readonly IndustryTypeBusinessRules _industrytypeBusinessRules;

            public UpdateIndustryTypeCommandHandler(IIndustryTypeRepository industrytypeRepository, IMapper mapper,
                                             IndustryTypeBusinessRules industrytypeBusinessRules)
            {
                _industrytypeRepository = industrytypeRepository;
                _mapper = mapper;
                _industrytypeBusinessRules = industrytypeBusinessRules;
            }

            public async Task<IDataResult<UpdatedIndustryTypeDto>> Handle(UpdateIndustryTypeCommand request, CancellationToken cancellationToken)
            {
                await _industrytypeBusinessRules.IndustryTypeNameCanNotBeDuplicatedWhenInserted(request.Name);


                IndustryType mappedEntity = _mapper.Map<IndustryType>(request);
                mappedEntity.UpdatedTime = DateTime.UtcNow;
                IndustryType updateIndustryType = await _industrytypeRepository.UpdateAsync(mappedEntity);
                UpdatedIndustryTypeDto updatedIndustryTypeDto = _mapper.Map<UpdatedIndustryTypeDto>(updateIndustryType);
                return new SuccessDataResult<UpdatedIndustryTypeDto>(updatedIndustryTypeDto, ResultMessages.Updated);
            }
        }
    }
}
