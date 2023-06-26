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
        public DeathRegistrar Registrar { get; set; }
        public virtual Deceased Deceased { get; set; }
        public virtual Issuer Issuer { get; set; }
    }
}