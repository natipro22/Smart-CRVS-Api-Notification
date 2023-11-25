using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDiv.CRVS.Application.Contracts.Request.BirthNotifications;

public class AddAttendant
{
    public Guid? Id { get; set; } = null;
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Date { get; set; }
    public Guid SkilledProfLookupId { get; set; }
    
}
