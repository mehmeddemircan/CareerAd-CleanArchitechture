using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.BusinessAspects
{
    public class SecuredOperationFilter : IAuthorizationFilter
    {
        private readonly string _roles;

        public SecuredOperationFilter(string roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

           

            var userRoles = user.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList();

            var requiredRoles = _roles.Split(',');

            if (!requiredRoles.Any(role => userRoles.Contains(role)))
            {
                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status401Unauthorized,
                    Title = "Authorization",
                    Detail = "You can not access this controller because of your role"
                };
                context.Result = new ObjectResult(problemDetails)
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
        }
    }
}
