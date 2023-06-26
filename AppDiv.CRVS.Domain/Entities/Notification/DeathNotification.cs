using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AppDiv.CRVS.Domain.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AppDiv.CRVS.Domain.Entities.Notifications
{
    public class DeathNotification : BaseAuditableEntity
    {
        public Guid PlaceOfDeathId { get; set; }
        public Guid FacilityOwnershipId { get; set; }
        public Guid FacilityAddressId { get; set; }
        public string CauseOfDeathStr { get; set; }
        public Guid IssuerId { get; set; }
        public DeathRegistrar Registrar { get; set; }
        public virtual Deceased Deceased { get; set; }
        public virtual Issuer Issuer { get; set; }

        [NotMapped]
        public JObject? CauseOfDeath
        {
            get
            {
                return JsonConvert.DeserializeObject<JObject>(string.IsNullOrEmpty(CauseOfDeathStr) ? "{}" : CauseOfDeathStr);
            }
            set
            {
                CauseOfDeathStr = value.ToString();
            }
        }
    }

    public class CauseOfDeath
    {
        public string? ImmediateCause { get; set; }
        public string? IntermediateCause { get; set; }
        public string? UnderlyingCause { get; set; }
    }
}