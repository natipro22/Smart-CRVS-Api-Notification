using System.ComponentModel.DataAnnotations.Schema;
using AppDiv.CRVS.Domain.Base;

namespace AppDiv.CRVS.Domain.Entities.Notifications
{
    public class Attendant : BaseAuditableEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Date { get; set; }
        public Guid SkilledProfLookupId { get; set; }
        public string? Language { get; set; } = default!;

        public Attendant() : base()
        {
            Language = lang;
        }
        
        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {MiddleName} {LastName}";
            }
        }
        // public ICollection<BirthNotification> BirthNotifications { get; set; } = Array.Empty<BirthNotification>();
    }
}