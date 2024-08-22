using Application.BusinessAspects;
using Core.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickReserve.Application.Features.Users.Commands.Delete;
using QuickReserve.Application.Features.Users.Queries.GetById;
using QuickReserve.Application.Features.Users.Queries.GetList;

namespace QuickReserve.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : BaseController
    {
        [HttpGet]
        [Authentication]
        [SecuredOperation("Admin")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserQuery getListUserQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListUserQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        [Authentication]
  
        public async Task<IActionResult> GetById([FromRoute] GetByIdUserQuery getByIdUserQuery)
        {
            var responseUserByIdDto = await Mediator.Send(getByIdUserQuery);
            return Ok(responseUserByIdDto);
        }


        [HttpDelete("{Id}")]
        [Authentication]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserCommand deleteUserCommand)
        {
            var responseDeleteUserDto = await Mediator.Send(deleteUserCommand);
            return Ok(responseDeleteUserDto);
        }
    }
}
