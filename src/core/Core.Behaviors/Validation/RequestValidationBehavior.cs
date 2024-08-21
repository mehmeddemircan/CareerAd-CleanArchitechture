using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Core.Application.Validation;

public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)

    {
        // Run all validators against the request
        var validationContext = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(validationContext, cancellationToken)));
        var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

        // If there are validation failures, throw a ValidationException
        if (failures.Count != 0)
        {
            throw new ValidationException(failures);
        }

        // Continue to the next handler in the pipeline
        return await next();
    }

    
}