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

namespace QuickReserve.Application.Features.IndustryTypes.Commands.Delete
{
    public partial class DeleteIndustryTypeCommand : IRequest<IDataResult<DeletedIndustryTypeDto>>
    {
        public int Id { get; set; }

        public class DeleteIndustryTypeCommandHandler : IRequestHandler<DeleteIndustryTypeCommand, IDataResult<DeletedIndustryTypeDto>>
        {
            private readonly IIndustryTypeRepository _industrytypeRepository;
            private readonly IMapper _mapper;
            private readonly IndustryTypeBusinessRules _industrytypeBusinessRules;

            public DeleteIndustryTypeCommandHandler(IIndustryTypeRepository industrytypeRepository, IMapper mapper,
                                             IndustryTypeBusinessRules industrytypeBusinessRules)
            {
                _industrytypeRepository = industrytypeRepository;
                _mapper = mapper;
                _industrytypeBusinessRules = industrytypeBusinessRules;
            }

            public async Task<IDataResult<DeletedIndustryTypeDto>> Handle(DeleteIndustryTypeCommand request, CancellationToken cancellationToken)
            {
                IndustryType mappedEntity = _mapper.Map<IndustryType>(request);
                IndustryType deleteIndustryType = await _industrytypeRepository.DeleteAsync(mappedEntity);
                DeletedIndustryTypeDto deletedIndustryTypeDto = _mapper.Map<DeletedIndustryTypeDto>(deleteIndustryType);
                return new SuccessDataResult<DeletedIndustryTypeDto>(deletedIndustryTypeDto, ResultMessages.Deleted);

            }


        }

    }
}
