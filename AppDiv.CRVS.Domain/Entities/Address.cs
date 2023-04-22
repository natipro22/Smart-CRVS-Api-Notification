
using System.ComponentModel.DataAnnotations.Schema;
using AppDiv.CRVS.Domain.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AppDiv.CRVS.Domain.Entities{
    public class Address : BaseAuditableEntity{
        public string AddressNameStr { get ; set; }
        public string StatisticCode { get; set; }
        public string Code { get; set; }
        public string AdminLevelLookupId { get; set;}
        public string AreaTypeLookupId { get; set; }
        public string? ParentAddressId { get; set; }
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
        public virtual Lookup AdminLevelLookup { get; set; }
        public virtual Lookup AreaTypeLookup { get; set; }
        public virtual Address ParentAddress { get; set; }
        public virtual ICollection<Address> ChildAddresses { get; set; }
        public virtual ICollection<PersonalInfo> PersonalInfos {get;}
        
    }
}