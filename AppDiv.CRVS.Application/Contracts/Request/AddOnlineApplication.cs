using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDiv.CRVS.Domain.Entities;
using Newtonsoft.Json.Linq;

namespace AppDiv.CRVS.Application.Contracts.Request;

public class AddOnlineApplication
{
    public JObject FullName { get; set; }
    public string Phone { get; set; }
    public string EventType { get; set; }
    public JObject Content { get; set; }
}
