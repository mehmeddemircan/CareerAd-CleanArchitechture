using Core.Constants;
using FluentValidation;
using QuickReserve.Application.Features.Companies.Commands.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.Companies.Validations
{
    public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
    {
        public UpdateCompanyCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage(ValidationMessages.NameIsRequired).MaximumLength(100).WithMessage(ValidationMessages.NameMaxCharacterExceed);
            RuleFor(c => c.IndustryTypeId).GreaterThan(0).WithMessage(ValidationMessages.IndustryTypeIdMustBeGreaterThanZero);
            RuleFor(c => c.Description).NotEmpty().WithMessage(ValidationMessages.DescriptionIsRequired).MaximumLength(500).WithMessage(ValidationMessages.DescriptionMaxCharacterExceed);
            RuleFor(c => c.Website).NotEmpty().WithMessage(ValidationMessages.WebsiteIsRequired);
        }
    }
}
