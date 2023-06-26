using AppDiv.CRVS.Domain.Base;

namespace AppDiv.CRVS.Domain.Entities.Notifications
{
    public class MotherInfo : BaseAuditableEntity
    {
        public Guid? BirthNotificationId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public virtual BirthNotification BirthNotification { get; set; }
    }
}