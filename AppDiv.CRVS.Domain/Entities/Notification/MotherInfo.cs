using System.ComponentModel.DataAnnotations.Schema;
using AppDiv.CRVS.Domain.Base;
using AppDiv.CRVS.Utility.Services;
using Newtonsoft.Json.Linq;

namespace AppDiv.CRVS.Domain.Entities.Notifications
{
    public class MotherInfo : BaseAuditableEntity
    {
        public Guid? BirthNotificationId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string BirthDateEt { get; set; }
        public string? Language { get; set; } = default!;

        public MotherInfo() : base()
        {
            Language = lang;
        }
        public virtual BirthNotification BirthNotification { get; set; }

        // [NotMapped]
        // public string? _BirthDateEt
        // {
        //     get { return BirthDateEt; }
        //     set
        //     {
        //         BirthDateEt = value;

        //         BirthDate = new CustomDateConverter(BirthDateEt).gorgorianDate;
        //     }
        // }
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
        public string FullName
        {
            get
            {
                return $"{FirstName} {MiddleName} {LastName}";
            }
        }

    }
}