using Core.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickReserve.Application.Features.JobAdForms.Commands.Create;
using QuickReserve.Application.Features.JobAdForms.Commands.Delete;
using QuickReserve.Application.Features.JobAdForms.Commands.Update;
using QuickReserve.Application.Features.JobAdForms.Queries.GetById;
using QuickReserve.Application.Features.JobAdForms.Queries.GetList;

namespace QuickReserve.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JobAdFormsController : BaseController
    {
        [HttpPost]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> Add([FromBody] CreateJobAdFormCommand createJobAdFormCommand)
        {
            var result = await Mediator.Send(createJobAdFormCommand);
            return Created("", result);
        }

        [HttpGet]
        //[Authentication]

        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListJobAdFormQuery getListJobAdFormQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListJobAdFormQuery);
            return Ok(result);
        }



        [HttpGet("{Id}")]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdJobAdFormQuery getByIdJobAdFormQuery)
        {
            var responseJobAdFormByIdDto = await Mediator.Send(getByIdJobAdFormQuery);
            return Ok(responseJobAdFormByIdDto);
        }

        [HttpPut]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateJobAdFormCommand updateJobAdFormCommand)
        {
            var responseUpdateJobAdFormDto = await Mediator.Send(updateJobAdFormCommand);
            return Ok(responseUpdateJobAdFormDto);
        }

        [HttpDelete("{Id}")]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> Delete([FromRoute] DeleteJobAdFormCommand deleteJobAdFormCommand)
        {
            var responseDeleteJobAdFormDto = await Mediator.Send(deleteJobAdFormCommand);
            return Ok(responseDeleteJobAdFormDto);
        }
    }
}
