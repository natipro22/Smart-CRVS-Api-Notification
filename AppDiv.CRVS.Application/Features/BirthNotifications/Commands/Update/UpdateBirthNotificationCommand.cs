using AppDiv.CRVS.Application.Common;
using AppDiv.CRVS.Application.Contracts.DTOs;
using AppDiv.CRVS.Application.Contracts.DTOs.BirthNotifications;
using AppDiv.CRVS.Application.Contracts.Request.BirthNotifications;
using AppDiv.CRVS.Domain.Entities.Notifications;
using MediatR;
namespace AppDiv.CRVS.Application.Features.BirthNotifications.Commands.Update
{
    public record UpdateBirthNotificationCommand : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }
        public Guid PlaceOfBirthId { get; set; }
        public Guid FacilityOwnershipId { get; set; }
        public Guid FacilityAddressId { get; set; }
        public MotherInfoDTO Mother { get; set; }
        public Guid DeliveryTypeId { get; set; }
        public Guid TypeOfBirth { get; set; }
        public Guid IssuerId { get; set; }
        public string IssuedDateEt { get; set; }
        public ICollection<ChildInfoDTO> Childrens { get; set; }
    }
}