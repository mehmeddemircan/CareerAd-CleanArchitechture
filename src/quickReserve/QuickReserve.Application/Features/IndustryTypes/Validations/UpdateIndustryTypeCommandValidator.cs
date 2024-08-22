using Core.Constants;
using FluentValidation;
using QuickReserve.Application.Features.IndustryTypes.Commands.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.IndustryTypes.Validations
{
    public class UpdateIndustryTypeCommandValidator : AbstractValidator<UpdateIndustryTypeCommand>
    {
        public UpdateIndustryTypeCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage(ValidationMessages.IndustryTypeNameCanNotBeEmpty);
            RuleFor(c => c.Name).MinimumLength(2).WithMessage(ValidationMessages.IndustryTypeNameMinLength);
        }
    }
}
