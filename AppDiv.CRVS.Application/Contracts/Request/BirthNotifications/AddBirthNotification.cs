using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Contracts.Request.BirthNotifications
{
    public class AddBirthNotification
    {
        public Guid PlaceOfBirthId { get; set; }
        public Guid FacilityOwnershipId { get; set; }
        public Guid FacilityAddressId { get; set; }
        public AddMotherInfo Mother { get; set; }
        public Guid DeliveryTypeId { get; set; }
        public Guid TypeOfBirth { get; set; }
        public Guid IssuerId { get; set; }
        public string IssuedDateEt { get; set; }
        public ICollection<AddChildInfo> Childrens { get; set; }
    }
}