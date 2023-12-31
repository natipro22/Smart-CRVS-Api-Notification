using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AppDiv.CRVS.Domain.Base;
using AppDiv.CRVS.Utility.Services;

namespace AppDiv.CRVS.Domain.Entities.Notifications
{
    public class BirthNotification : BaseAuditableEntity
    {
        public string PlaceOfBirthId { get; set; }
        public Guid FacilityOwnershipId { get; set; }
        public Guid FacilityAddressId { get; set; }
        public MotherInfo Mother { get; set; }
        public Guid DeliveryTypeId { get; set; }
        public Guid TypeOfBirth { get; set; }
        public Guid IssuerId { get; set; }
        public DateTime IssuedDate { get; set; }
        public string IssuedDateEt { get; set; }
        public ICollection<ChildInfo> Childrens { get; set; }
        public Guid AttendantId { get; set; }
        public Attendant Attendant { get; set; }
        public string? Language { get; set; } = default!;

        public BirthNotification() : base()
        {
            Language = lang;
        }

        [NotMapped]
        public string? _IssuedDateEt
        {
            get { return IssuedDateEt; }
            set
            {
                IssuedDateEt = value;

                IssuedDate = new CustomDateConverter(IssuedDateEt).gorgorianDate;
            }
        }

    }
}