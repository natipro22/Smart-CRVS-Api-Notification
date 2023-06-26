using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Contracts.Request.DeathNotifications
{
    public class AddDeathNotificationRequest
    {
        public Guid PlaceOfDeathId { get; set; }
        public Guid FacilityOwnershipId { get; set; }
        public Guid FacilityAddressId { get; set; }
        public string CauseOfDeathStr { get; set; }
        public Guid IssuerId { get; set; }
        public virtual AddDeathRegistrar Registrar { get; set; }
        public virtual AddDeceased Deceased { get; set; }
    }
}