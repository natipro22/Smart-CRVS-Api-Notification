using AppDiv.CRVS.Domain.Entities;
using Newtonsoft.Json.Linq;

namespace AppDiv.CRVS.Application.Contracts.Request
{
    public class UpdateCourtCaseRequest
    {
        public Guid Id { get; set; }
        public Guid CourtLookupId { get; set; }
        public string CourtCaseNumber { get; set; }
        public DateTime ConfirmedDate { get; set; }

    }
}