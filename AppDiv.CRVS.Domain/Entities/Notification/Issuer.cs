using AppDiv.CRVS.Domain.Base;

namespace AppDiv.CRVS.Domain.Entities.Notifications
{
    public class Issuer : BaseAuditableEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string IssuedDate { get; set; }
        public virtual ICollection<DeathNotification> DeathNotification { get; set; }
        public virtual ICollection<BirthNotification> BirthNotification { get; set; }
    }
}