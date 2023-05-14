using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Application.Features.AddressLookup.Query.GetAddressByParent;
using AppDiv.CRVS.Application.Features.Search;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
namespace AppDiv.CRVS.API.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Member,User")]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SearchController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly ILogger<SearchController> _Ilog;
        public SearchController(ISender mediator, ILogger<SearchController> Ilog)
        {
            _mediator = mediator;
            _Ilog = Ilog;
        }
        [HttpGet]
        [Route("GetPersonalInfo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<object> GetByParent([FromQuery] string SearchString)
        {
            return await _mediator.Send(new GetPersonalInfoQuery { SearchString = SearchString });
        }

    }
}