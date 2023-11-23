using System.ComponentModel.DataAnnotations.Schema;
using AppDiv.CRVS.Domain.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AppDiv.CRVS.Domain.Entities
{
    public class Court : BaseAuditableEntity
    {
        public String? NameStr { get; set; }
        public Guid? AddressId { get; set; }
        public string? DescriptionStr { get; set; }

        public virtual Address Address { get; set; }
        [NotMapped]
        public JObject Name
        {
            get
            {
                try
                {

                    return JsonConvert.DeserializeObject<JObject>(string.IsNullOrEmpty(NameStr) ? "{}" : NameStr) ?? new JObject();
                }
                catch (System.Exception)
                {

                    return new JObject();
                }
            }
            set
            {
                NameStr = value.ToString();
            }
        }

        [NotMapped]
        public string? NameLang
        {
            get
            {
                return lang == null ? null : Name.Value<string>(lang);
            }
        }
        [NotMapped]
        public JObject? Description
        {
            get
            {
                try
                {
                    return JsonConvert.DeserializeObject<JObject>(string.IsNullOrEmpty(DescriptionStr) ? "{}" : DescriptionStr);

                }
                catch (System.Exception)
                {

                    return new JObject();
                }
            }
            set
            {
                DescriptionStr = value?.ToString();
            }
        }
        [NotMapped]
        public string? DescriptionLang
        {
            get
            {
                return lang == null ? null : Description?.Value<string>(lang);
            }
        }


    }
}