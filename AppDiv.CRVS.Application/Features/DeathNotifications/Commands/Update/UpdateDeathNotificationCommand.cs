using AppDiv.CRVS.Application.Common;
using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Application.Contracts.Request.DeathNotifications;
using AppDiv.CRVS.Domain.Entities.Notifications;
using MediatR;
namespace AppDiv.CRVS.Application.Features.DeathNotifications.Commands.Create
{
    public record UpdateDeathNotificationCommand : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }
        public Guid PlaceOfDeathId { get; set; }
        public Guid FacilityOwnershipId { get; set; }
        public Guid FacilityAddressId { get; set; }
        public string CauseOfDeathStr { get; set; }
        public Guid IssuerId { get; set; }
        public virtual UpdateDeathRegistrar Registrar { get; set; }
        public virtual UpdateDeceased Deceased { get; set; }
    }
}