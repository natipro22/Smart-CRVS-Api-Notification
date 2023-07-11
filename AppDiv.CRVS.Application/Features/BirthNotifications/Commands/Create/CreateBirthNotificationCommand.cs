
using AppDiv.CRVS.Application.Contracts.Request.BirthNotifications;
using MediatR;
namespace AppDiv.CRVS.Application.Features.BirthNotifications.Commands.Create
{
    // Create birth notification command.
    public record CreateBirthNotificationCommand(AddBirthNotification BirthNotification) : IRequest<CreateBirthNotificationComandResponse>
    {

    }
}