using Core.Constants;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using QuickReserve.Application.Repositories;
using QuickReserve.Domain.Entities;
using QuickReserve.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.IndustryTypes.Rules
{
    public class IndustryTypeBusinessRules
    {
        private readonly IIndustryTypeRepository _industrytypeRepository;

        public IndustryTypeBusinessRules(IIndustryTypeRepository industrytypeRepository)
        {
            _industrytypeRepository = industrytypeRepository;
        }

        public async Task IndustryTypeNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<IndustryType> result = await _industrytypeRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any())
            {
                throw new BusinessException(ExceptionMessages.IndustryTypeNameExists);
            }
        }
        public void IndustryTypeShouldExistWhenRequested(IndustryType industrytype)
        {
            if (industrytype == null)
            {
                throw new BusinessException(ExceptionMessages.IndustryTypeShouldExistWhenRequested);
            }
        }
    }
}
