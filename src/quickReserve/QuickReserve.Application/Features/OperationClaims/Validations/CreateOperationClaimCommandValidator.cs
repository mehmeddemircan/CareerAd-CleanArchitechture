
using Core.Constants;
using FluentValidation;
using QuickReserve.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.OperationClaims.Validations
{
    public class CreateOperationClaimCommandValidator : AbstractValidator<CreateOperationClaimCommand>
    {
        public CreateOperationClaimCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage(ValidationMessages.OperationClaimNameCanNotBeEmpty);
            RuleFor(c => c.Name).MinimumLength(2).WithMessage(ValidationMessages.OperationClaimNameMinLength);
        }
    }
}
