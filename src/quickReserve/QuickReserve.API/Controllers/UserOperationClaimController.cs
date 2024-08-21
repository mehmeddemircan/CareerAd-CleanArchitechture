using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickReserve.Application.Features.UserOperationClaims.Commands.Create;

namespace QuickReserve.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserOperationClaimController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> AddRoleToUser([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
        {
            var result = await Mediator.Send(createUserOperationClaimCommand);
            return Created("", result);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        //{
        //    GetListUserOperationClaimQuery getListUserOperationClaimQuery = new() { PageRequest = pageRequest };
        //    var result = await Mediator.Send(getListUserOperationClaimQuery);
        //    return Ok(result);
        //}



        //[HttpGet("{Id}")]
        //public async Task<IActionResult> GetById([FromRoute] GetByIdUserOperationClaimQuery getByIdUserOperationClaimQuery)
        //{
        //    var responseUserOperationClaimByIdDto = await Mediator.Send(getByIdUserOperationClaimQuery);
        //    return Ok(responseUserOperationClaimByIdDto);
        //}

        //[HttpPut]
        //public async Task<IActionResult> UpdateRoleOfUser([FromBody] UpdateUserOperationClaimCommand updateUserOperationClaimCommand)
        //{
        //    var responseUpdateUserOperationClaimDto = await Mediator.Send(updateUserOperationClaimCommand);
        //    return Ok(responseUpdateUserOperationClaimDto);
        //}

        //[HttpDelete("{Id}")]
        //public async Task<IActionResult> RemoveRoleOfUser([FromRoute] DeleteUserOperationClaimCommand deleteUserOperationClaimCommand)
        //{
        //    var responseDeleteUserOperationClaimDto = await Mediator.Send(deleteUserOperationClaimCommand);
        //    return Ok(responseDeleteUserOperationClaimDto);
        //}
    }
}
