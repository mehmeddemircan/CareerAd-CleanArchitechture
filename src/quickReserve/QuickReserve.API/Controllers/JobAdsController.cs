using Core.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickReserve.Application.Features.Companies.Commands.Create;
using QuickReserve.Application.Features.Companies.Commands.Delete;
using QuickReserve.Application.Features.Companies.Commands.Update;
using QuickReserve.Application.Features.Companies.Queries.GetById;
using QuickReserve.Application.Features.Companies.Queries.GetList;
using QuickReserve.Application.Features.JobAds.Commands.Create;
using QuickReserve.Application.Features.JobAds.Commands.Delete;
using QuickReserve.Application.Features.JobAds.Commands.Update;
using QuickReserve.Application.Features.JobAds.Queries.GetById;
using QuickReserve.Application.Features.JobAds.Queries.GetList;

namespace QuickReserve.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JobAdsController : BaseController
    {
        [HttpPost]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> Add([FromBody] CreateJobAdCommand createJobAdCommand)
        {
            var result = await Mediator.Send(createJobAdCommand);
            return Created("", result);
        }

        [HttpGet]
        //[Authentication]

        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListJobAdQuery getListJobAdQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListJobAdQuery);
            return Ok(result);
        }



        [HttpGet("{Id}")]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdJobAdQuery getByIdJobAdQuery)
        {
            var responseJobAdByIdDto = await Mediator.Send(getByIdJobAdQuery);
            return Ok(responseJobAdByIdDto);
        }

        [HttpPut]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateJobAdCommand updateJobAdCommand)
        {
            var responseUpdateJobAdDto = await Mediator.Send(updateJobAdCommand);
            return Ok(responseUpdateJobAdDto);
        }

        [HttpDelete("{Id}")]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> Delete([FromRoute] DeleteJobAdCommand deleteJobAdCommand)
        {
            var responseDeleteJobAdDto = await Mediator.Send(deleteJobAdCommand);
            return Ok(responseDeleteJobAdDto);
        }
    }
}
