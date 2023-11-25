using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDiv.CRVS.Domain.Entities.Notifications;

namespace AppDiv.CRVS.Application.Contracts.Request.DeathNotifications
{
    public class AddDeathNotificationRequest
    {
        public string PlaceOfDeathId { get; set; }
        public Guid FacilityOwnershipId { get; set; }
        public Guid FacilityAddressId { get; set; }
        public CauseOfDeath CauseOfDeath { get; set; }
        public Guid IssuerId { get; set; }
        public string IssuedDateEt { get; set; }
        public virtual AddDeathRegistrar Registrar { get; set; }
        public virtual AddDeceased Deceased { get; set; }
    }
}