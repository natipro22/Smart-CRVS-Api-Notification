using AppDiv.CRVS.Domain.Base;

namespace AppDiv.CRVS.Domain.Entities.Notifications
{
    public class Deceased : BaseAuditableEntity
    {
        public Guid? DeathNotificationId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Guid TitileLookupId { get; set; }
        public int Age { get; set; }
        public Guid SexLookupId { get; set; }
        public string DateOfDeath { get; set; }
        public bool IsDay { get; set; }
        public string Time { get; set; }

        public virtual DeathNotification DeathNotification { get; set; }
    }
}