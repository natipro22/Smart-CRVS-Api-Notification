using System.ComponentModel.DataAnnotations.Schema;
using AppDiv.CRVS.Domain.Base;
using AppDiv.CRVS.Utility.Services;

namespace AppDiv.CRVS.Domain.Entities.Notifications
{
    public class ChildInfo : BaseAuditableEntity
    {
        public Guid? BirthNotificationId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public float WeightAtBirth { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DateOfBirthEt { get; set; }
        public Guid SexLookupId { get; set; }
        public string Time { get; set; }
        public bool IsDay { get; set; }
        // public Guid TypeOfBirth { get; set; }
        public virtual BirthNotification BirthNotification { get; set; }
        public string? Language { get; set; } = default!;

        public ChildInfo() : base()
        {
            Language = lang;
        }

        [NotMapped]
        public string? _DateOfBirthEt
        {
            get { return DateOfBirthEt; }
            set
            {
                DateOfBirthEt = value;
                DateOfBirth = new CustomDateConverter(DateOfBirthEt).gorgorianDate;
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