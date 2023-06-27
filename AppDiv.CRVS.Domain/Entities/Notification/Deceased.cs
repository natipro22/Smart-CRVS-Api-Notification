using System.ComponentModel.DataAnnotations.Schema;
using AppDiv.CRVS.Domain.Base;
using AppDiv.CRVS.Utility.Services;

namespace AppDiv.CRVS.Domain.Entities.Notifications
{
    public class Deceased : BaseAuditableEntity
    {
        public Guid? DeathNotificationId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Guid TitileLookupId { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthDateEt { get; set; }
        public Guid SexLookupId { get; set; }
        public DateTime DateOfDeath { get; set; }
        public string DateOfDeathEt { get; set; }
        public bool IsDay { get; set; }
        public string Time { get; set; }

        public virtual DeathNotification DeathNotification { get; set; }

        [NotMapped]
        public int Age
        {
            get { return DateTime.Now.Year - BirthDate.Year; }
            set
            {
                BirthDate = DateTime.Now.AddYears(-value);
                BirthDateEt = new CustomDateConverter(BirthDate).ethiopianDate;
            }
        }

        [NotMapped]
        public string? _DateOfDeathEt
        {
            get { return DateOfDeathEt; }
            set
            {
                DateOfDeathEt = value;
                DateOfDeath = new CustomDateConverter(DateOfDeathEt).gorgorianDate;
            }
        }
    }
}