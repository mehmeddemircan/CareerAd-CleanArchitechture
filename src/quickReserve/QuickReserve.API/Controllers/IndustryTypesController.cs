using Application.BusinessAspects;
using Core.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickReserve.Application.Features.IndustryTypes.Commands.Create;
using QuickReserve.Application.Features.IndustryTypes.Commands.Delete;
using QuickReserve.Application.Features.IndustryTypes.Commands.Update;
using QuickReserve.Application.Features.IndustryTypes.Queries.GetById;
using QuickReserve.Application.Features.IndustryTypes.Queries.GetList;


namespace QuickReserve.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IndustryTypesController : BaseController
    {
        [HttpPost]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> Add([FromBody] CreateIndustryTypeCommand createIndustryTypeCommand)
        {
            var result = await Mediator.Send(createIndustryTypeCommand);
            return Created("", result);
        }

        [HttpGet]
        //[Authentication]
      
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListIndustryTypeQuery getListIndustryTypeQuery = new() { PageRequest = pageRequest };
            var result = await Mediator.Send(getListIndustryTypeQuery);
            return Ok(result);
        }



        [HttpGet("{Id}")]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdIndustryTypeQuery getByIdIndustryTypeQuery)
        {
            var responseIndustryTypeByIdDto = await Mediator.Send(getByIdIndustryTypeQuery);
            return Ok(responseIndustryTypeByIdDto);
        }

        [HttpPut]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateIndustryTypeCommand updateIndustryTypeCommand)
        {
            var responseUpdateIndustryTypeDto = await Mediator.Send(updateIndustryTypeCommand);
            return Ok(responseUpdateIndustryTypeDto);
        }

        [HttpDelete("{Id}")]
        //[Authentication]
        //[SecuredOperation("Admin")]
        public async Task<IActionResult> Delete([FromRoute] DeleteIndustryTypeCommand deleteIndustryTypeCommand)
        {
            var responseDeleteIndustryTypeDto = await Mediator.Send(deleteIndustryTypeCommand);
            return Ok(responseDeleteIndustryTypeDto);
        }
    }
}
