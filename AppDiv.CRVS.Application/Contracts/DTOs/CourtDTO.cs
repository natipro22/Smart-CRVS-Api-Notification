using System.ComponentModel.DataAnnotations.Schema;
using AppDiv.CRVS.Application.Contracts.Request;
using AppDiv.CRVS.Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AppDiv.CRVS.Application.Contracts.DTOs
{
    public class CourtDTO
    {
        public Guid id { get; set; }
        public Guid AddressId { get; set; }
        public string? NameStr { get; set; }
        [NotMapped]
        public JObject? Name
        {
            get
            {
                try
                {
                    return JsonConvert.DeserializeObject<JObject>(string.IsNullOrEmpty(NameStr) ? "{}" : NameStr);

                }
                catch (System.Exception)
                {

                    return null;
                }

            }
            set
            {
                NameStr = value?.ToString();
            }
        }

        public string? DescriptionStr { get; set; }
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

                    return null;
                }

            }
            set
            {
                DescriptionStr = value?.ToString();
            }
        }
        public AddressResponseDTOE? CourtAddress { get; set; }

    }
    public class CourtDTOV
    {
        public Guid id { get; set; }
        public Guid AddressId { get; set; }
        public string? NameStr { get; set; }
        [NotMapped]
        public JObject? Name
        {
            get
            {
                try
                {
                    return JsonConvert.DeserializeObject<JObject>(string.IsNullOrEmpty(NameStr) ? "{}" : NameStr);

                }
                catch (System.Exception)
                {

                    return null;
                }

            }
            set
            {
                NameStr = value?.ToString();
            }
        }

        public string? DescriptionStr { get; set; }
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

                    return null;
                }

            }
            set
            {
                DescriptionStr = value?.ToString();
            }
        }
        public AddressResponseDTOView? CourtAddress { get; set; }

    }
}