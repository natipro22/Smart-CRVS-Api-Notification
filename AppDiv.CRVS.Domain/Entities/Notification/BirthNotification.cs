using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDiv.CRVS.Domain.Base;

namespace AppDiv.CRVS.Domain.Entities.Notifications
{
    public class BirthNotification : BaseAuditableEntity
    {
        public Guid PlaceOfBirthId { get; set; }
        public Guid FacilityOwnershipId { get; set; }
        public Guid FacilityAddressId { get; set; }
        public MotherInfo Mother { get; set; }
        public Guid DeliveryTypeId { get; set; }
        public Guid TypeOfBirth { get; set; }
        public Guid IssuerId { get; set; }
        public virtual Issuer Issuer { get; set; }
        public ICollection<ChildInfo> Childrens { get; set; }

    }
}