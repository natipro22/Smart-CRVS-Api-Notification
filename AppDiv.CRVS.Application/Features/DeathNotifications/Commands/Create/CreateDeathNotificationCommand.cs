
using AppDiv.CRVS.Application.Contracts.Request.DeathNotifications;
using MediatR;
namespace AppDiv.CRVS.Application.Features.DeathNotifications.Commands.Create
{
    // Create death notification command.
    public record CreateDeathNotificationCommand(AddDeathNotificationRequest DeathNotification) : IRequest<CreateDeathNotificationComandResponse>
    {

    }
}