
using System.ComponentModel.DataAnnotations.Schema;
using AppDiv.CRVS.Domain.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AppDiv.CRVS.Domain.Entities
{
    public class Lookup : BaseAuditableEntity
    {
        public string Key { get; set; }
        public string ValueStr { get; set; }
        public string? DescriptionStr { get; set; }
        public string? StatisticCode { get; set; }
        public string? Code { get; set; }
        public bool IsSystemLookup { get; set; } = false;
        public string? EventType { get; set; }
        [NotMapped]
        public JObject? Description
        {
            get
            {
                return JsonConvert.DeserializeObject<JObject>(string.IsNullOrEmpty(DescriptionStr) ? "{}" : DescriptionStr);
            }
            set
            {
                DescriptionStr = value.ToString();
            }
        }
        [NotMapped]
        public JObject Value
        {
            get
            {
                return JsonConvert.DeserializeObject<JObject>(string.IsNullOrEmpty(ValueStr) ? "{}" : ValueStr);
            }
            set
            {
                ValueStr = value.ToString();
            }
        }
        // public virtual ICollection<Address> AddressAdminLevelNavigation { get; set; }
        // public virtual ICollection<Address> AddressAreaTypeNavigation { get; set; }
        // public virtual ICollection<Address> AdminTypeNavigation { get; set; }
        [NotMapped]
        public string? ValueLang
        {
            get
            {
                return Value.Value<string>(lang);
            }
        }

    }
}