using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AppDiv.CRVS.Domain.Base;
using AppDiv.CRVS.Utility.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AppDiv.CRVS.Domain.Entities.Notifications
{
    public class DeathNotification : BaseAuditableEntity
    {
        public string PlaceOfDeathId { get; set; }
        public Guid FacilityOwnershipId { get; set; }
        public Guid FacilityAddressId { get; set; }
        public string CauseOfDeathStr { get; set; }
        public Guid IssuerId { get; set; }
        public DateTime IssuedDate { get; set; }
        public string IssuedDateEt { get; set; }
        public DeathRegistrar Registrar { get; set; }
        public virtual Deceased Deceased { get; set; }
        public string? Language { get; set; } = default!;
        // public virtual Issuer Issuer { get; set; }

        public DeathNotification() : base()
        {
            Language = lang;
        }
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

        [NotMapped]
        public string? _IssuedDateEt
        {
            get { return IssuedDateEt; }
            set
            {
                IssuedDateEt = value;

                IssuedDate = new CustomDateConverter(IssuedDateEt).gorgorianDate;
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