using Core.JWT.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuickReserve.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>() ?? throw new InvalidOperationException("IMediator cannot be retrieved from request services.");
        private IMediator? _mediator;
        protected string GetIpAddress()
        {
            string ipAddress = Request.Headers.ContainsKey("X-Forwarded-For")
                ? Request.Headers["X-Forwarded-For"].ToString()
                : HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString()
                    ?? throw new InvalidOperationException("IP address cannot be retrieved from request.");
            return ipAddress;
        }

        protected Guid GetUserIdFromRequest()
        {
            var userId = Guid.Parse(HttpContext.User.GetUserId().ToString()!);
            return userId;
        }

    }
}
