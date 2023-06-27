using AppDiv.CRVS.Application.Common;
using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Application.Features.DeathNotifications.Query;
using AppDiv.CRVS.Domain;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using AppDiv.CRVS.Application.Features.DeathNotifications.Commands.Create;
using AppDiv.CRVS.Application.Features.DeathNotifications.Query.GetAllDeathNotification;
using AppDiv.CRVS.Application.Features.DeathNotifications.Query.GetDeathNotificationById;
using AppDiv.CRVS.Application.Features.DeathNotifications.Commands.Delete;
using AppDiv.CRVS.Application.Features.DeathNotifications.Commands.Update;

namespace AppDiv.CRVS.API.Controllers
{
    public class DeathNotificationController : ApiControllerBase
    {

        [HttpPost("Create")]
        // [ProducesDefaultResponseType(typeof(int))]
        public async Task<ActionResult> CreateDeathNotification(CreateDeathNotificationCommand command)
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
        public async Task<PaginatedList<DeathNotificationDTO>> Get([FromQuery] GetAllDeathNotificationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<DeathNotificationDTO> Get(Guid id)
        {
            return await Mediator.Send(new GetDeathNotificationById(id));
        }


        [HttpPut("Edit/{id}")]
        public async Task<ActionResult> Edit(Guid id, [FromBody] UpdateDeathNotificationCommand command)
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
        public async Task<ActionResult> DeleteDeathNotification(Guid id)
        {
            try
            {
                var result = await Mediator.Send(new DeleteDeathNotificationCommand { Id = id});
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