using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Contracts.Request
{
    public class AddBirthNotificationRequest
    {
        // public Guid BirthEventId { get; set; }
        public Guid DeliveryTypeLookupId { get; set; }
        public float WeightAtBirth { get; set; }
        public Guid SkilledProfLookupId { get; set; }
        public string NotficationSerialNumber { get; set; }
    }
}