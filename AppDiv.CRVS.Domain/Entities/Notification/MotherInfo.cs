using System.ComponentModel.DataAnnotations.Schema;
using AppDiv.CRVS.Domain.Base;
using AppDiv.CRVS.Utility.Services;

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

    }
}