using Application.BusinessAspects;
using Core.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickReserve.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using QuickReserve.Application.Features.OperationClaims.Commands.Delete;
using QuickReserve.Application.Features.OperationClaims.Commands.Update;
using QuickReserve.Application.Features.OperationClaims.Queries.GetById;
using QuickReserve.Application.Features.OperationClaims.Queries.GetListOperationClaim;

namespace QuickReserve.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OperationClaimsController : BaseController
    {

        [HttpPost]
        [Authentication]
        [SecuredOperation("Admin")]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
        {
            var result = await Mediator.Send(createOperationClaimCommand);
            return Created("", result);
        }

        [HttpGet]
        [Authentication]
        [SecuredOperation("Admin")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListOperationClaimQuery getListOperationClaimQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListOperationClaimQuery);
            return Ok(result);
        }



        [HttpGet("{Id}")]
        [Authentication]
        [SecuredOperation("Admin")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdOperationClaimQuery getByIdOperationClaimQuery)
        {
            var responseOperationClaimByIdDto = await Mediator.Send(getByIdOperationClaimQuery);
            return Ok(responseOperationClaimByIdDto);
        }

        [HttpPut]
        [Authentication]
        [SecuredOperation("Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaimCommand)
        {
            var responseUpdateOperationClaimDto = await Mediator.Send(updateOperationClaimCommand);
            return Ok(responseUpdateOperationClaimDto);
        }

        [HttpDelete("{Id}")]
        [Authentication]
        [SecuredOperation("Admin")]
        public async Task<IActionResult> Delete([FromRoute] DeleteOperationClaimCommand deleteOperationClaimCommand)
        {
            var responseDeleteOperationClaimDto = await Mediator.Send(deleteOperationClaimCommand);
            return Ok(responseDeleteOperationClaimDto);
        }

    }
}
