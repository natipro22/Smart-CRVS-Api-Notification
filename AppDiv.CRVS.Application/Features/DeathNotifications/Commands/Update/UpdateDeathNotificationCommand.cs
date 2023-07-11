using AppDiv.CRVS.Application.Common;
using AppDiv.CRVS.Application.Contracts.DTOs.DeathNotifications;
using AppDiv.CRVS.Domain.Entities.Notifications;
using MediatR;
namespace AppDiv.CRVS.Application.Features.DeathNotifications.Commands.Update
{
    public record UpdateDeathNotificationCommand : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }
        public Guid PlaceOfDeathId { get; set; }
        public Guid FacilityOwnershipId { get; set; }
        public Guid FacilityAddressId { get; set; }
        public CauseOfDeath CauseOfDeath { get; set; }
        public Guid IssuerId { get; set; }
        public string IssuedDateEt { get; set; }
        public virtual DeathRegistrarDTO Registrar { get; set; }
        public virtual DeceasedDTO Deceased { get; set; }
    }
}