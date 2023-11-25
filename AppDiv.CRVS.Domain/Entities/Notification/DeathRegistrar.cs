using System.ComponentModel.DataAnnotations.Schema;
using AppDiv.CRVS.Domain.Base;
using AppDiv.CRVS.Utility.Services;

namespace AppDiv.CRVS.Domain.Entities.Notifications
{
    public class DeathRegistrar : BaseAuditableEntity
    {
        public Guid? DeathNotificationId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }
        public string RegistrationDateEt { get; set; }

        public virtual DeathNotification DeathNotification { get; set; }
        public string? Language { get; set; } = default!;

        public DeathRegistrar() : base()
        {
            Language = lang;
        }

        [NotMapped]
        public string? _RegistrationDateEt
        {
            get { return RegistrationDateEt; }
            set
            {
                RegistrationDateEt = value;

                RegistrationDate = new CustomDateConverter(RegistrationDateEt).gorgorianDate;
            }
        }

        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {MiddleName} {LastName}";
            }
        }
    }
}