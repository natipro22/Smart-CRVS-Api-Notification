using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Contracts.DTOs.BirthNotifications
{
    public class ChildInfoDTO
    {
        public Guid Id { get; set; }
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