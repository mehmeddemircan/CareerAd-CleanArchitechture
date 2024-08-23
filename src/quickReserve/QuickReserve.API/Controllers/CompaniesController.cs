using Core.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickReserve.Application.Features.Companies.Commands.Create;
using QuickReserve.Application.Features.Companies.Commands.Delete;
using QuickReserve.Application.Features.Companies.Commands.Update;
using QuickReserve.Application.Features.Companies.Queries.GetById;
using QuickReserve.Application.Features.Companies.Queries.GetList;


namespace QuickReserve.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompaniesController : BaseController
    {
        [HttpPost]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> Add([FromBody] CreateCompanyCommand createCompanyCommand)
        {
            var result = await Mediator.Send(createCompanyCommand);
            return Created("", result);
        }

        [HttpGet]
        //[Authentication]

        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListCompanyQuery getListCompanyQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListCompanyQuery);
            return Ok(result);
        }



        [HttpGet("{Id}")]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCompanyQuery getByIdCompanyQuery)
        {
            var responseCompanyByIdDto = await Mediator.Send(getByIdCompanyQuery);
            return Ok(responseCompanyByIdDto);
        }

        [HttpPut]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateCompanyCommand updateCompanyCommand)
        {
            var responseUpdateCompanyDto = await Mediator.Send(updateCompanyCommand);
            return Ok(responseUpdateCompanyDto);
        }

        [HttpDelete("{Id}")]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCompanyCommand deleteCompanyCommand)
        {
            var responseDeleteCompanyDto = await Mediator.Send(deleteCompanyCommand);
            return Ok(responseDeleteCompanyDto);
        }
    }
}
