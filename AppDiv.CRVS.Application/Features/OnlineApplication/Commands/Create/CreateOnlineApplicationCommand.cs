
using AppDiv.CRVS.Application.Contracts.Request;
using MediatR;
namespace AppDiv.CRVS.Application.Features.OnlineApplications.Commands.Create
{
    // Create birth notification command.
    public record CreateOnlineApplicationCommand(AddOnlineApplication OnlineApplication) : IRequest<CreateOnlineApplicationComandResponse>
    {

    }
}