using AppDiv.CRVS.Application.Common;
using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Application.Features.OnlineApplications.Query;
using AppDiv.CRVS.Domain;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using AppDiv.CRVS.Application.Features.OnlineApplications.Commands.Create;
using AppDiv.CRVS.Application.Features.OnlineApplications.Query.GetAllOnlineApplication;
using AppDiv.CRVS.Application.Features.OnlineApplications.Query.GetOnlineApplicationById;
using AppDiv.CRVS.Application.Features.OnlineApplications.Commands.Delete;
using AppDiv.CRVS.Application.Features.OnlineApplications.Commands.Update;

namespace AppDiv.CRVS.API.Controllers
{
    public class OnlineApplicationController : ApiControllerBase
    {

        [HttpPost("Create")]
        // [ProducesDefaultResponseType(typeof(int))]
        public async Task<ActionResult> CreateOnlineApplication(CreateOnlineApplicationCommand command)
        {
            var res = await Mediator.Send(command);
            if (!res.Success)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }



        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<PaginatedList<OnlineApplicationDTO>> Get([FromQuery] GetAllOnlineApplicationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<OnlineApplicationDTO> Get(Guid id)
        {
            return await Mediator.Send(new GetOnlineApplicationById(id));
        }


        [HttpPut("Edit/{id}")]
        public async Task<ActionResult> Edit(Guid id, [FromBody] UpdateOnlineApplicationCommand command)
        {
            try
            {
                if (command.Id == id)
                {
                    var result = await Mediator.Send(command);
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteOnlineApplication(Guid id)
        {
            try
            {
                var result = await Mediator.Send(new DeleteOnlineApplicationCommand { Id = id});
                if(result.Status == 200)
                    return Ok(result);
                else
                    return BadRequest(result);                
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

    }
}