
using System.ComponentModel.DataAnnotations.Schema;
using AppDiv.CRVS.Domain.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AppDiv.CRVS.Domain.Entities
{
    public class Address : BaseAuditableEntity
    {
        public string AddressNameStr { get; set; }
        public string StatisticCode { get; set; }
        public string Code { get; set; }
        public string? CodePerfix { get; set; }
        public string? CodePostfix { get; set; }
        public int AdminLevel { get; set; } = 1;
        public bool Status { get; set; } = false;
        public Guid? OldAddressId { get; set; }
        public Guid? AdminTypeLookupId { get; set; }
        public Guid? AreaTypeLookupId { get; set; }
        public DateTime? WorkStartedOn { get; set; }
        public Guid? ParentAddressId { get; set; }

        [NotMapped]
        public JObject AddressName
        {
            get
            {
                return JsonConvert.DeserializeObject<JObject>(string.IsNullOrEmpty(AddressNameStr) ? "{}" : AddressNameStr);
            }
            set
            {
                AddressNameStr = value.ToString();
            }
        }
        //public virtual Lookup AdminLevelLookup { get; set; }
        public virtual Lookup AreaTypeLookup { get; set; }
        public virtual Lookup AdminTypeLookup { get; set; }
        public virtual Address ParentAddress { get; set; }
        public virtual ICollection<Address> ChildAddresses { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationuserAddresses { get; set; }
        [NotMapped]
        public string? AddressNameLang
        {
            get
            {
                return AddressName.Value<string>(lang);
            }
        }

    }
}