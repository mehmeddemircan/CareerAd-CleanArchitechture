
using Core.CrossCuttingConcerns.Exceptions;
using Core.JWT.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;


namespace Core.Application.Authorization;

public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
       where TRequest : IRequest<TResponse>, ISecuredRequest
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        List<string>? roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

        if (roleClaims == null) throw new AuthorizationException("Claims not found.");

        bool isNotMatchedARoleClaimWithRequestRoles = !roleClaims.Any(roleClaim => request.Roles.Contains(roleClaim));

        if (isNotMatchedARoleClaimWithRequestRoles) throw new AuthorizationException("You are not authorized.");

        TResponse response = await next();
        return response;
    }
}