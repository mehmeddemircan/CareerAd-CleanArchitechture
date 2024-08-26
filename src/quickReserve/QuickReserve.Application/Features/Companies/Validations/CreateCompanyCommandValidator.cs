using Core.Constants;
using FluentValidation;
using QuickReserve.Application.Features.Companies.Commands.Create;
using QuickReserve.Application.Features.UserOperationClaims.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.Companies.Validations
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage(ValidationMessages.NameIsRequired).MaximumLength(100).WithMessage(ValidationMessages.NameMaxCharacterExceed);
            RuleFor(c => c.IndustryTypeId).GreaterThan(0).WithMessage(ValidationMessages.IndustryTypeIdMustBeGreaterThanZero);
            RuleFor(c => c.Description).NotEmpty().WithMessage(ValidationMessages.DescriptionIsRequired).MaximumLength(500).WithMessage(ValidationMessages.DescriptionMaxCharacterExceed);
            RuleFor(c => c.Website).NotEmpty().WithMessage(ValidationMessages.WebsiteIsRequired);
        }
    }

}
