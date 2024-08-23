using Core.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickReserve.Application.Features.Answers.Commands.Create;
using QuickReserve.Application.Features.Answers.Commands.Delete;
using QuickReserve.Application.Features.Answers.Commands.Update;
using QuickReserve.Application.Features.Answers.Queries.GetById;
using QuickReserve.Application.Features.Answers.Queries.GetList;
using QuickReserve.Application.Features.Companies.Commands.Create;
using QuickReserve.Application.Features.Companies.Commands.Delete;
using QuickReserve.Application.Features.Companies.Commands.Update;
using QuickReserve.Application.Features.Companies.Queries.GetById;
using QuickReserve.Application.Features.Companies.Queries.GetList;

namespace QuickReserve.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnswersController : BaseController
    {
        [HttpPost]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> Add([FromBody] CreateAnswerCommand createAnswerCommand)
        {
            var result = await Mediator.Send(createAnswerCommand);
            return Created("", result);
        }

        [HttpGet]
        //[Authentication]

        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListAnswerQuery getListAnswerQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListAnswerQuery);
            return Ok(result);
        }



        [HttpGet("{Id}")]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdAnswerQuery getByIdAnswerQuery)
        {
            var responseAnswerByIdDto = await Mediator.Send(getByIdAnswerQuery);
            return Ok(responseAnswerByIdDto);
        }

        [HttpPut]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateAnswerCommand updateAnswerCommand)
        {
            var responseUpdateAnswerDto = await Mediator.Send(updateAnswerCommand);
            return Ok(responseUpdateAnswerDto);
        }

        [HttpDelete("{Id}")]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> Delete([FromRoute] DeleteAnswerCommand deleteAnswerCommand)
        {
            var responseDeleteAnswerDto = await Mediator.Send(deleteAnswerCommand);
            return Ok(responseDeleteAnswerDto);
        }
    }
}
