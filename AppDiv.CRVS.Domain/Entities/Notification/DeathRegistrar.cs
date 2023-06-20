using AppDiv.CRVS.Domain.Base;

namespace AppDiv.CRVS.Domain.Entities.Notifications
{
    public class DeathRegistrar : BaseAuditableEntity
    {
        public Guid? DeathNotificationId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string RegistrationDate { get; set; }

        // public virtual DeathNotification DeathNotification { get; set; }
    }
}