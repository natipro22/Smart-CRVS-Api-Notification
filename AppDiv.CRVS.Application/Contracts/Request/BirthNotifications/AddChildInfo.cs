using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Contracts.Request.BirthNotifications
{
    public class AddChildInfo
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public float WeightAtBirth { get; set; }
        public string DateOfBirthEt { get; set; }
        public Guid SexLookupId { get; set; }
        public string Time { get; set; }
        public bool IsDay { get; set; }
    }
}