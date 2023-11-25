using AppDiv.CRVS.Application.Contracts.DTOs.BirthNotifications;
using AppDiv.CRVS.Application.Contracts.Request.BirthNotifications;
using AppDiv.CRVS.Domain.Entities.Notifications;
using Newtonsoft.Json.Linq;

namespace AppDiv.CRVS.Application.Contracts.DTOs
{
    public class BirthNotificationDTO
    {
        public Guid Id { get; set; }
        public string PlaceOfBirthId { get; set; }
        public Guid FacilityOwnershipId { get; set; }
        public Guid FacilityAddressId { get; set; }
        public MotherInfoDTO Mother { get; set; }
        public Guid DeliveryTypeId { get; set; }
        public Guid TypeOfBirth { get; set; }
        public Guid IssuerId { get; set; }
        public string IssuedDateEt { get; set; }
        public AddAttendant Attendant { get; set; }
        public ICollection<ChildInfoDTO> Childrens { get; set; }
    }
}