
using Microsoft.AspNetCore.Mvc;
using AppDiv.CRVS.Application.Features.Courts.Query.GetAllCourt;
using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Application.Features.Lookups.Query.GetLookupById;
using AppDiv.CRVS.Application.Features.Courts.Query.GetById;

namespace AppDiv.CRVS.API.Controllers
{
    public class CourtController : ApiControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> GetAllCourt()
        {

            return Ok(await Mediator.Send(new GetAllCourtQuery()));
        }

        [HttpGet("Lookup")]
        public async Task<IActionResult> GetAllLookup()
        {
            return Ok(await Mediator.Send(new GetAllForLookup()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<object> GetById(Guid id)
        {
            return await Mediator.Send(new CourtGetByIdQuery(id));
        }
    }
}