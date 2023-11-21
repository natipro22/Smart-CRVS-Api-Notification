using AppDiv.CRVS.API.Helpers;
using AppDiv.CRVS.Application.Common;
using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Application.Features.Settings.Query.GetAllSettings;
using AppDiv.CRVS.Application.Features.Settings.Query.GetSettingByKey;
using AppDiv.CRVS.Application.Features.Settings.Query.GetSettingsById;
using AppDiv.CRVS.Domain.Entities;

using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AppDiv.CRVS.API.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Member,User")]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SettingController : ApiControllerBase
    {
        private readonly ISender _mediator;
        private readonly ILogger<SettingController> _Ilog;
        public SettingController(ISender mediator, ILogger<SettingController> Ilog)
        {
            _mediator = mediator;
            _Ilog = Ilog;
        }


        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<List<SettingDTO>> Get([FromQuery] GetAllSettingQuery query)
        {
            return await _mediator.Send(query);
        }
       

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Setting> Get(Guid id)
        {
            return await _mediator.Send(new GetSettingByIdQuery { Id = id });
        }

        

        [HttpGet]
        [Route("key")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<SettingDTO>> GetByKey([FromQuery] string Key)
        {
            return await _mediator.Send(new GetSettingByKeyQuery { Key = Key });
        }
    }
}