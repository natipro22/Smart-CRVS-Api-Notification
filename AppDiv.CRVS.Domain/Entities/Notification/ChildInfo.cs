using AppDiv.CRVS.Domain.Base;

namespace AppDiv.CRVS.Domain.Entities.Notifications
{
    public class ChildInfo : BaseAuditableEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public float WeightAtBirth { get; set; }
        public string DateOfBirth { get; set; }
        public Guid SexLookupId { get; set; }
        public string Time { get; set; }
        public bool IsDay { get; set; }
        // public Guid TypeOfBirth { get; set; }
    }
}