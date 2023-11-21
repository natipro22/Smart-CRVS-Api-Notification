using AppDiv.CRVS.Application.Common;
using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Domain.Entities.Notifications;
using MediatR;
using Newtonsoft.Json.Linq;
namespace AppDiv.CRVS.Application.Features.OnlineApplications.Commands.Update
{
    public record UpdateOnlineApplicationCommand : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }
        public JObject FullName { get; set; }
        public string Phone { get; set; }
        public string EventType { get; set; }
        public JObject Content { get; set; }
    }
}