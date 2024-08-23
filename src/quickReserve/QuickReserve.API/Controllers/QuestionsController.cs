using Core.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickReserve.Application.Features.Companies.Commands.Create;
using QuickReserve.Application.Features.Companies.Commands.Delete;
using QuickReserve.Application.Features.Companies.Commands.Update;
using QuickReserve.Application.Features.Companies.Queries.GetById;
using QuickReserve.Application.Features.Companies.Queries.GetList;
using QuickReserve.Application.Features.Questions.Commands.Create;
using QuickReserve.Application.Features.Questions.Commands.Delete;
using QuickReserve.Application.Features.Questions.Commands.Update;
using QuickReserve.Application.Features.Questions.Queries.GetById;
using QuickReserve.Application.Features.Questions.Queries.GetList;

namespace QuickReserve.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuestionsController : BaseController
    {
        [HttpPost]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> Add([FromBody] CreateQuestionCommand createQuestionCommand)
        {
            var result = await Mediator.Send(createQuestionCommand);
            return Created("", result);
        }

        [HttpGet]
        //[Authentication]

        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListQuestionQuery getListQuestionQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListQuestionQuery);
            return Ok(result);
        }



        [HttpGet("{Id}")]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdQuestionQuery getByIdQuestionQuery)
        {
            var responseQuestionByIdDto = await Mediator.Send(getByIdQuestionQuery);
            return Ok(responseQuestionByIdDto);
        }

        [HttpPut]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateQuestionCommand updateQuestionCommand)
        {
            var responseUpdateQuestionDto = await Mediator.Send(updateQuestionCommand);
            return Ok(responseUpdateQuestionDto);
        }

        [HttpDelete("{Id}")]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> Delete([FromRoute] DeleteQuestionCommand deleteQuestionCommand)
        {
            var responseDeleteQuestionDto = await Mediator.Send(deleteQuestionCommand);
            return Ok(responseDeleteQuestionDto);
        }
    }
}
