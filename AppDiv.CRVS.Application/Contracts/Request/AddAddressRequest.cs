using Newtonsoft.Json.Linq;

namespace AppDiv.CRVS.Application.Contracts.Request
{
    public class AddAddressRequest
    {
        public JObject AddressName { get; set; }
        public string StatisticCode { get; set; }
        public string Code { get; set; }
        public Guid AdminLevelLookupId { get; set; }
        public Guid AreaTypeLookupId { get; set; }
        public Guid? ParentAddressId { get; set; }

    }
}