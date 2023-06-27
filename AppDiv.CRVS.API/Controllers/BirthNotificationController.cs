using AppDiv.CRVS.Application.Common;
using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Application.Features.BirthNotifications.Query;
using AppDiv.CRVS.Domain;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using AppDiv.CRVS.Application.Features.BirthNotifications.Commands.Create;
using AppDiv.CRVS.Application.Features.BirthNotifications.Query.GetAllBirthNotification;
using AppDiv.CRVS.Application.Features.BirthNotifications.Query.GetBirthNotificationById;
using AppDiv.CRVS.Application.Features.BirthNotifications.Commands.Delete;
using AppDiv.CRVS.Application.Features.BirthNotifications.Commands.Update;

namespace AppDiv.CRVS.API.Controllers
{
    public class BirthNotificationController : ApiControllerBase
    {

        [HttpPost("Create")]
        // [ProducesDefaultResponseType(typeof(int))]
        public async Task<ActionResult> CreateBirthNotification(CreateBirthNotificationCommand command)
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
        public async Task<PaginatedList<BirthNotificationDTO>> Get([FromQuery] GetAllBirthNotificationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<BirthNotificationDTO> Get(Guid id)
        {
            return await Mediator.Send(new GetBirthNotificationById(id));
        }


        [HttpPut("Edit/{id}")]
        public async Task<ActionResult> Edit(Guid id, [FromBody] UpdateBirthNotificationCommand command)
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
        public async Task<ActionResult> DeleteBirthNotification(Guid id)
        {
            try
            {
                var result = await Mediator.Send(new DeleteBirthNotificationCommand { Id = id});
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