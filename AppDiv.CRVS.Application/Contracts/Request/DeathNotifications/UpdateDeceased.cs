using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Contracts.Request.DeathNotifications
{
    public class UpdateDeceased
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Guid TitileLookupId { get; set; }
        public int Age { get; set; }
        public Guid SexLookupId { get; set; }
        public string DateOfDeath { get; set; }
        public bool IsDay { get; set; }
        public string Time { get; set; }
    }
}