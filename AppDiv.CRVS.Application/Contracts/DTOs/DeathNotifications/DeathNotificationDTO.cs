using AppDiv.CRVS.Application.Contracts.DTOs.DeathNotifications;
using AppDiv.CRVS.Domain.Entities.Notifications;
using Newtonsoft.Json.Linq;

namespace AppDiv.CRVS.Application.Contracts.DTOs
{
    public class DeathNotificationDTO
    {
        public Guid PlaceOfDeathId { get; set; }
        public Guid FacilityOwnershipId { get; set; }
        public Guid FacilityAddressId { get; set; }
        public JObject CauseOfDeath { get; set; }
        public DeathRegistrarDTO Registrar { get; set; }
        public virtual DeceasedDTO Deceased { get; set; }
        public virtual IssuerDTO Issuer { get; set; }
    }
}