using Core.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickReserve.Application.Features.Companies.Commands.Create;
using QuickReserve.Application.Features.Companies.Commands.Delete;
using QuickReserve.Application.Features.Companies.Commands.Update;
using QuickReserve.Application.Features.Companies.Queries.GetById;
using QuickReserve.Application.Features.Companies.Queries.GetList;
using QuickReserve.Application.Features.JobAdApplications.Commands.Create;
using QuickReserve.Application.Features.JobAdApplications.Commands.Delete;
using QuickReserve.Application.Features.JobAdApplications.Commands.Update;
using QuickReserve.Application.Features.JobAdApplications.Queries.GetById;
using QuickReserve.Application.Features.JobAdApplications.Queries.GetList;

namespace QuickReserve.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JobAdApplication : BaseController
    {
        [HttpPost]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> ApplyForJobAd([FromBody] CreateJobAdApplicationCommand createJobAdApplicationCommand)
        {
            var result = await Mediator.Send(createJobAdApplicationCommand);
            return Created("", result);
        }

        [HttpGet]
        //[Authentication]

        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListJobAdApplicationQuery getListJobAdApplicationQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListJobAdApplicationQuery);
            return Ok(result);
        }



        [HttpGet("{Id}")]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdJobAdApplicationQuery getByIdJobAdApplicationQuery)
        {
            var responseJobAdApplicationByIdDto = await Mediator.Send(getByIdJobAdApplicationQuery);
            return Ok(responseJobAdApplicationByIdDto);
        }

        [HttpPut]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> UpdateApplication([FromBody] UpdateJobAdApplicationCommand updateJobAdApplicationCommand)
        {
            var responseUpdateJobAdApplicationDto = await Mediator.Send(updateJobAdApplicationCommand);
            return Ok(responseUpdateJobAdApplicationDto);
        }

        [HttpDelete("{Id}")]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> Delete([FromRoute] DeleteJobAdApplicationCommand deleteJobAdApplicationCommand)
        {
            var responseDeleteJobAdApplicationDto = await Mediator.Send(deleteJobAdApplicationCommand);
            return Ok(responseDeleteJobAdApplicationDto);
        }
    }
}
